﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Input;
using System.Collections.ObjectModel;
using System.Windows;
using QuanLyPhongMachTu.Model;

namespace QuanLyPhongMachTu.ViewModel
{
    public class DiagnosisViewModel : BaseViewModel
    {
        public ICommand AddMedicineCommand { get; set; }
        public ICommand DeleteMedicineCommand { get; set; }
        public ICommand CheckoutCommand { get; set; }

        public DiagnosisCollector Information { get; set; }             //Thông tin khám bệnh

        public ObservableCollection<DiseaseCollector> DiseaseList { get; set; }    //Danh sách bệnh

        public ObservableCollection<MedicineCollector> MedicineList { get; set; }       //Danh sách thuốc để chọn

        public ObservableCollection<UseCollector> UsingList { get; set; }               //Danh sách cách dùng thuốc

        private ObservableCollection<DetailPrescriptionCollector> _prescription;        // Đơn thuốc của bệnh nhân
        public ObservableCollection<DetailPrescriptionCollector> Prescription
        {
            get
            {
                return _prescription;
            }
            set
            {
                _prescription = value;
                OnPropertyChanged();
            }
        }

        public DiagnosisViewModel(int patientID)
        {
            InitialDiagnosis(patientID);
            LoadDiseaseList();
            LoadMedicineList();
            LoadUsingList();
            Prescription = new ObservableCollection<DetailPrescriptionCollector>();
            
            AddMedicineCommand = new RelayCommand<DiagnosisScreen>((p) =>
            {
                return true;
            }, (p) =>
            {
                Prescription.Add(new DetailPrescriptionCollector());
            });

            DeleteMedicineCommand = new RelayCommand<DetailPrescriptionCollector>((p) =>
            {
                return true;
            }, HandleDeleteMedicine);

            CheckoutCommand = new RelayCommand<DiagnosisScreen>((p) =>
            {
                return true;

            }, (p) =>
            {
                HandleCheckout();
            });

        }

        private void HandleDeleteMedicine(DetailPrescriptionCollector target)
        {
            Prescription.Remove(target);
        }

        private void InitialDiagnosis(int patientID)
        {
            var result = from pk in DataProvider.Ins.DB.PhieuKhams
                         join bn in DataProvider.Ins.DB.BenhNhans on pk.MaBN equals bn.MaSoBN
                         where bn.MaSoBN == patientID
                         select bn;

            Information = new DiagnosisCollector(result.First().MaSoBN, result.First().HoTen);
        }

        private void LoadDiseaseList()
        {
            var diseases = DataProvider.Ins.DB.LoaiBenhs.ToList();
            DiseaseList = new ObservableCollection<DiseaseCollector>();
            foreach(var disease in diseases)
            {
                DiseaseList.Add(new DiseaseCollector()
                {
                    MaBenh = disease.MaBenh,
                    TenBenh = disease.TenBenh
                });
            }
        }

        private void LoadMedicineList()
        {
            var medicines = (from lt in DataProvider.Ins.DB.LoaiThuocs
                             join dv in DataProvider.Ins.DB.DonVis on lt.MaDonVi equals dv.MaDonVi
                             select new {
                                 MaThuoc = lt.MaThuoc,
                                 TenThuoc = lt.TenThuoc,
                                 DonVi = dv.TenDonVi,
                                 Gia = lt.Gia
                             }).ToList() ;
            MedicineList = new ObservableCollection<MedicineCollector>();
            foreach(var medicine in medicines)
            {
                MedicineList.Add(new MedicineCollector()
                {
                    MaThuoc = medicine.MaThuoc,
                    TenThuoc = medicine.TenThuoc,
                    DonVi = medicine.DonVi,
                    Gia = medicine.Gia
                });
            }
        }

        private void LoadUsingList()
        {
            var ways = DataProvider.Ins.DB.CachDungs.ToList();
            UsingList = new ObservableCollection<UseCollector>();
            foreach(var way in ways)
            {
                UsingList.Add(new UseCollector()
                {
                    MaCachDung = way.MaCachDung,
                    CachSuDung = way.CachSuDung
                });
            }
        }

        private void HandleCheckout()
        {
            var newID = DataProvider.Ins.DB.PhieuKhams.Max(pk => pk.MaPK) + 1;
            var diagnosisCost = DataProvider.Ins.DB.QuyDinhs.Where(qd => qd.TenQuyDinh == "SoTienKham").First().SoLuongQD;
            int medicineCost = 0;
            foreach(var medicine in Prescription)
            {
                int cost = medicine.SoLuong * MedicineList.Where(medi => medi.MaThuoc == medicine.MaThuoc).First().Gia;
                medicineCost += cost;
            }
            DataProvider.Ins.DB.PhieuKhams.Add(new PhieuKham()
            {
                MaPK = newID,
                MaBN = Information.MaBN,
                TrieuChung = Information.TrieuChung,
                MaLoaiBenh = Information.MaLoaibenh,
                TienKham = diagnosisCost,
                TienThuoc = medicineCost,
                NgayKham = Information.NgayKham,
                Xoa = false
            });
            var newPrescriptionID = DataProvider.Ins.DB.DonThuocs.Max(dt => dt.MaDT) + 1;
            DataProvider.Ins.DB.DonThuocs.Add(new DonThuoc()
            {
                MaDT = newPrescriptionID,
                MaPK = newID
            });

            foreach(var medicine in Prescription)
            {
                DataProvider.Ins.DB.ChiTietDonThuocs.Add(new ChiTietDonThuoc()
                {
                    MaDT = newPrescriptionID,
                    MaThuoc = medicine.MaThuoc,
                    SoLuong = medicine.SoLuong,
                    MaCachDung = medicine.MaCachDung
                });
            }
            DataProvider.Ins.DB.SaveChanges();
        }
    }
}
