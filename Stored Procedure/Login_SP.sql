use QuanLyNoiThat
go

create proc sp_login @tentk nvarchar(max), @matkhau nvarchar(max)
as
	begin 
		select TaiKhoan.TenTK, TaiKhoan.MatKhau, TaiKhoan.Email, LoaiTaiKhoan.TenLoaiTK from TaiKhoan join LoaiTaiKhoan on LoaiTaiKhoan.ID = TaiKhoan.LoaiTaiKhoanID
		where TaiKhoan.TenTK = @tentk and TaiKhoan.MatKhau = @matkhau
	end
go