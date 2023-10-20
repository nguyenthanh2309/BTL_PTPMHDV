use QuanLyNoiThat
go

create proc sp_get_hoa_don_by_id @id nvarchar(10)
as
	begin	
		select hd.*, (
			select cthd.* from ChiTietHoaDon as cthd
			where hd.ID = cthd.HoaDonID for JSON PATH)
			as json_list_chitiethoadon from HoaDon as hd 
			where hd.ID = @id
	end
go

create proc sp_create_hoa_don 
@trangthai nvarchar(20),
@tenkh nvarchar(max),
@sdt nvarchar(12),
@diachi nvarchar(max),
@json_list_chitiethoadon nvarchar(max)
as
	begin
		declare @HoaDonID int
		insert into HoaDon values (
			@tenkh, @sdt, @diachi
		)
		set @HoaDonID = (select SCOPE_IDENTITY());
		if (@json_list_chitiethoadon is not null)
		begin	
			insert into ChiTietHoaDon(HoaDonID, SanPhamID, SoLuong, TongGia)
			select 
				   @HoaDonID,
				   JSON_VALUE(p.value, '$.SanPhamID'),
				   JSON_VALUE(p.value, '$SoLuong'),
				   JSON_VALUE(p.value, '$TongGia')
			from OPENJSON(@json_list_chitiethoadon) as p
			end;
		select '';
	end
go

create proc sp_update_hoa_don 
@id nvarchar(10),
@trangthai nvarchar(20),
@tenkh nvarchar(max),
@sdt nvarchar(12),
@diachi nvarchar(max),
@json_list_chitiethoadon nvarchar(max)
as 
	begin
		update HoaDon
		set
			TenKH = @tenkh,
			SDT = @sdt,
			DiaChi = @diachi,
			TrangThai = @trangthai
		where ID = @id;
				if(@json_list_chitiethoadon IS NOT NULL) 
		begin
		   select
			  JSON_VALUE(p.value, '$.ID') as ChiTietHoaDonID,
			  JSON_VALUE(p.value, '$.HoaDonID') as HoaDonID,
			  JSON_VALUE(p.value, '$.SanPhamID') as SanPhamID,
			  JSON_VALUE(p.value, '$.SoLuong') as SoLuong,
			  JSON_VALUE(p.value, '$.TongGia') as TongGia,
			  JSON_VALUE(p.value, '$.status') as status 
			  into #Results 
		   from OPENJSON(@json_list_chitiethoadon) as p;
		 
		 -- Insert data to table with STATUS = 1;
			insert into ChiTietHoaDon(HoaDonID, 
						  SanPhamID,
                          SoLuong,
						  TongGia) 
			   select
				  #Results.SanPhamID,
				  @id,
				  #Results.SoLuong,
				  #Results.TongGia
			   from  #Results 
			   where #Results.status = '1' 
			
			-- Update data to table with STATUS = 2
			  update ChiTietHoaDon 
			  set
				 SoLuong = #Results.SoLuong,
				 TongGia = #Results.TongGia
			  from #Results 
			  where  ChiTietHoaDon.ID = #Results.ChiTietHoaDonID AND #Results.status = '2';
			
			-- Delete data to table with STATUS = 3
			delete ChiTietHoaDon
			from ChiTietHoaDon 
			join #Results
				on ChiTietHoaDon.ID=#Results.ChiTietHoaDonID
			where #Results.status = '3';
			drop table #Results;
		end;
        select ''; 
	end
go

create proc sp_delete_hoa_don @id nvarchar(10)
as 
	begin
		delete from HoaDon
		where HoaDon.ID = @id
	end
go