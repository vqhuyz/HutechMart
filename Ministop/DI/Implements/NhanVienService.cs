using Dapper;
using Ministop.Common;
using Ministop.DI.Interfaces;
using Ministop.Models;
using Ministop.ModelsView;
using PagedList;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;

namespace Ministop.DI.Implements
{
    public class NhanVienService : INhanVienService
    {
        public IEnumerable<NhanVienViewModel> GetAll(string search, int page, int pagesize)
        {
            using (var connection = new SqlConnection(ConnectionS.connectionString))
            {
                if (!string.IsNullOrEmpty(search))
                {
                    var nhanVien = connection.Query<NhanVienViewModel>("sp_Search_NhanVien", new { tenNV = search, soDT = search, chucVu = search }, commandType: CommandType.StoredProcedure);
                    return nhanVien.ToPagedList(page, pagesize);
                }
                else
                    return connection.Query<NhanVienViewModel>("sp_GetAll_NhanVien", commandType: CommandType.StoredProcedure).ToPagedList(page, pagesize);
            }
        }

        public NhanVienViewModel GetById(int id)
        {
            using (var connection = new SqlConnection(ConnectionS.connectionString))
            {
                return connection.QueryFirstOrDefault<NhanVienViewModel>("sp_GetById_NhanVien", new { Id = id }, commandType: CommandType.StoredProcedure);
            }
        }

        public bool ThemMoi(NhanVienViewModel _nhanVien, string fileAnh)
        {
            bool result = false;
            NhanVien nhanVien = new NhanVien();
            DangNhap dangNhap = new DangNhap();
            using (var db = new MinistopDbContext())
            {
                using (var trans = db.Database.BeginTransaction())
                {
                    try
                    {
                        nhanVien.TenNhanVien = _nhanVien.TenNhanVien;
                        nhanVien.GioiTinh = _nhanVien.GioiTinh;
                        nhanVien.NgaySinh = _nhanVien.NgaySinh;
                        nhanVien.SoCMND = _nhanVien.SoCMND;
                        nhanVien.SoDT = _nhanVien.SoDT;
                        nhanVien.Email = _nhanVien.Email;
                        nhanVien.HinhAnh = fileAnh;
                        nhanVien.DiaChi = _nhanVien.DiaChi;
                        nhanVien.ChucVu = _nhanVien.ChucVu;
                        nhanVien.MucLuong = _nhanVien.MucLuong;
                        nhanVien.NgayThamGia = DateTime.Now;
                        nhanVien.GhiChu = _nhanVien.GhiChu;
                        nhanVien.TinhTrang = true;

                        db.NhanViens.Add(nhanVien);
                        db.SaveChanges();
 
                        dangNhap.NhanVienID = nhanVien.ID;
                        dangNhap.TaiKhoan = _nhanVien.SoDT;
                        dangNhap.MatKhau = Encryptor.MD5Hash("1");
                        dangNhap.TinhTrang = true;
                        dangNhap.PhanQuyenID = 2;

                        db.DangNhaps.Add(dangNhap);
                        db.SaveChanges();
                        trans.Commit();
                        result = true;
                }
                    catch (Exception)
                {
                    trans.Rollback();
                }
            }
            }
            return result;
        }

        public bool CapNhat(NhanVienViewModel _nhanVien)
        {
            bool result = false;
            using (var db = new MinistopDbContext())
            {
                var nhanVien = db.NhanViens.Find(_nhanVien.ID);
                using (var trans = db.Database.BeginTransaction())
                {
                    try
                    {
                        nhanVien.TenNhanVien = _nhanVien.TenNhanVien;
                        nhanVien.GioiTinh = _nhanVien.GioiTinh;
                        nhanVien.NgaySinh = _nhanVien.NgaySinh;
                        nhanVien.SoCMND = _nhanVien.SoCMND;
                        nhanVien.SoDT = _nhanVien.SoDT;
                        nhanVien.Email = _nhanVien.Email;
                        nhanVien.DiaChi = _nhanVien.DiaChi;
                        nhanVien.ChucVu = _nhanVien.ChucVu;
                        nhanVien.MucLuong = _nhanVien.MucLuong;
                        nhanVien.NgayCapNhat = DateTime.Now;
                        nhanVien.GhiChu = _nhanVien.GhiChu;
                        nhanVien.TinhTrang = true;
                        db.SaveChanges();
                        trans.Commit();
                        result = true;
                    }
                    catch (Exception)
                    {
                        trans.Rollback();
                    }
                }
            }
            return result;
        }

        public bool Xoa(int id)
        {
            bool result = false;
            using (var db = new MinistopDbContext())
            {
                var nhanVien = db.NhanViens.Find(id);
                nhanVien.TinhTrang = false;
                nhanVien.NgayCapNhat = DateTime.Now;
                db.SaveChanges();
                result = true;
            }
            return result;
        }

        public bool DoiMatKhau(int id, string MatKhauCu, string MatKhauMoi)
        {
            bool result = false;
            using (var db = new MinistopDbContext())
            {
                var thongtin = db.DangNhaps.Find(id);
                if(thongtin.MatKhau == Encryptor.MD5Hash(MatKhauCu))
                {
                    using (var trans = db.Database.BeginTransaction())
                    {
                        try
                        {
                            thongtin.MatKhau = Encryptor.MD5Hash(MatKhauMoi);
                            db.SaveChanges();
                            trans.Commit();
                            result = true;
                        }
                        catch (Exception)
                        {
                            trans.Rollback();
                        }
                    }
                }
            }
            return result;
        }
    }
}