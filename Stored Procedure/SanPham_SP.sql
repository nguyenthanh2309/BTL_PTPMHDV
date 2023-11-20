use QuanLyNoiThat
go

--lay san pham theo id
create proc sp_get_san_pham_by_id @id int
as
    begin
      select *
	  from SanPham
      where SanPham.ID= @id;
    end;
go

-- tao 1 san pham moi
create proc sp_create_san_pham 
@tensp nvarchar(max),
@danhmucid nvarchar(10),
@nhaccid nvarchar(10),
@gia int,
@soluong int,
@vatlieu nvarchar(max),
@kichthuoc nvarchar(max)
as
	begin 
		insert into SanPham values (
			@tensp, @danhmucid, @nhaccid, @vatlieu, @kichthuoc, @soluong, @gia
		)
	end
go

--cap nhat san pham
create proc sp_update_san_pham 
@id int,
@tensp nvarchar(max),
@danhmucid nvarchar(10),
@nhaccid nvarchar(10),
@gia int,
@soluong int,
@vatlieu nvarchar(max),
@kichthuoc nvarchar(max)
as
	begin
		update SanPham
		set TenSP = @tensp,
		DanhMucID = @danhmucid,
		NhaCCID = @nhaccid,
		VatLieu = @vatlieu,
		KichThuoc = @kichthuoc,
		SoLuong = @soluong,
		Gia = @gia
		where ID = @id
	end
go

--xoa san pham
create proc sp_delete_san_pham @id int
as 
	begin
		delete from SanPham where ID = @id
	end
go

--lay tat ca san pham
create proc sp_get_all_san_pham 
as
	begin
		select SanPham.ID, SanPham.TenSP, DanhMuc.TenDanhMuc, NhaCC.TenNhaCC, SanPham.VatLieu, SanPham.KichThuoc, SanPham.SoLuong, SanPham.Gia from ((SanPham
		join DanhMuc on SanPham.DanhMucID = DanhMuc.ID)
		join NhaCC on SanPham.NhaCCID = NhaCC.ID)
	end
go

--lay san pham ban chay nhat
create proc sp_get_san_pham_ban_chay @soluong int 
as
	begin
		declare @quantity int
		select * from SanPham join ChiTietHoaDon on ChiTietHoaDon.SanPhamID = SanPham.ID
		
	end
go