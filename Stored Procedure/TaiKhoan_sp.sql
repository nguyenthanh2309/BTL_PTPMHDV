use QuanLyNoiThat
go

create proc sp_get_tk_by_id @id nvarchar(10)
as
	begin 
		select * from TaiKhoan where ID = @id
	end
go
create proc sp_get_all_tk 
as
	begin
		select TaiKhoan.ID, TaiKhoan.TenTK, TaiKhoan.MatKhau, TaiKhoan.Email, LoaiTaiKhoan.TenLoaiTK from TaiKhoan join LoaiTaiKhoan on TaiKhoan.LoaiTaiKhoanID = LoaiTaiKhoan.ID
	end
go

create proc sp_create_tk
@tentk nvarchar(max),
@matkhau nvarchar(max),
@email nvarchar(max),
@loaitkid nvarchar(10)
as
	begin
		insert into TaiKhoan values (
			@tentk, @matkhau, @email, @loaitkid
		)
	end
go

create proc sp_update_tk @json nvarchar(max)
as
	begin
		if(@json is not null)
		begin
			select
					JSON_VALUE(ListToEdit.value,'$.id') as ID,
					JSON_VALUE(ListToEdit.value, '$.tenTk') as TenTaiKhoan,
					JSON_VALUE(ListToEdit.value, '$.matKhau') as MatKhau,
					JSON_VALUE(ListToEdit.value, '$.email') as Email,
					JSON_VALUE(ListToEdit.value, '$.loaiTaiKhoanID') as LoaiTaiKhoanID
				into #ListToEdit
			from OPENJSON(@json) as ListToEdit
			update TaiKhoan
			set TaiKhoan.TenTK = #ListToEdit.TenTaiKhoan,
				TaiKhoan.MatKhau = #ListToEdit.MatKhau,
				TaiKhoan.Email = #ListToEdit.Email,
				TaiKhoan.LoaiTaiKhoanID = #ListToEdit.LoaiTaiKhoanID
			from #ListToEdit
			where TaiKhoan.ID = #ListToEdit.ID
		end
	end
go

create proc sp_delete_tk @id nvarchar(10)
as
	begin 
		delete from TaiKhoan where ID = @id
	end
go