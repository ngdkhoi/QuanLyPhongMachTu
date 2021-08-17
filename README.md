# QuanLyPhongMachTu
Yêu cầu cài đặt
- Microsoft SQL Server Express

Hướng dẫn cách build
- Bật commander line
- Gõ câu lệnh "whoami" rồi enter
- Copy server của bạn (phần trước dấu \ ở bước 2)
- Server name có định dạng (...)\EXPRESS với (...) là phần được copy ở bước trên (ví dụ: DESKTOP-QRD7LLH\SQLEXPRESS)
- Copy server name
- Chạy script khởi tạo database từ DatabaseScript.sql
	Nếu người dùng có Microsoft Visual Code
- Chạy App.config trong source code và replace phần server name vào phần data source cũ của code
- Chạy file QuanLyPhongMachTu.sln và nhấn tổ hợp phím Ctrl + Shift + B để re-build và ctrl + F5 để chạy chương trình
	Nếu người dùng không có Microsoft Visual Code
- Mở file Release và mở file QuanLyPhongMachTu.exe.config và replace phần server name vào phần data source cũ của code
- Chạy file QuanLyPhongMachTu.exe
