<%@ WebHandler Language="C#" Class="ThemGioHang" %>

using System;
using System.Collections.Generic;
using System.Web;
using System.Web.SessionState;
using baiTapLonBanh;

public class ThemGioHang : IHttpHandler, IRequiresSessionState
{
    public void ProcessRequest(HttpContext context)
    {
        context.Response.ContentType = "application/json";

        
        if (context.Request.HttpMethod != "POST")
        {
            context.Response.StatusCode = 405;
            context.Response.Write("{\"ok\":false}");
            return;
        }

        string maBanh =
            (context.Request.Form["maBanh"] ?? "").Trim();

        if (maBanh == "" || maBanh.Length > 50)
        {
            context.Response.StatusCode = 400;
            context.Response.Write("{\"ok\":false}");
            return;
        }

       
        SanPhamBanh banh = null;

        context.Application.Lock();

        try
        {
            List<SanPhamBanh> ds =
                context.Application["DanhSachSanPham"]
                as List<SanPhamBanh>;

            if (ds != null)
            {
                foreach (SanPhamBanh x in ds)
                {
                    if (x.maBanh == maBanh)
                    {
                        banh = x;
                        break;
                    }
                }
            }
        }
        finally
        {
            context.Application.UnLock();
        }

        
        if (banh == null)
        {
            context.Response.StatusCode = 404;
            context.Response.Write("{\"ok\":false}");
            return;
        }

       
        string maSize = GioHangKey.LaBanhKem(banh)
            ? "16"
            : null;

       
        string khoa = GioHangKey.Tao(banh.maBanh, maSize);

        Dictionary<string, int> gioHang =
            context.Session["GioHang"]
            as Dictionary<string, int>;

        if (gioHang == null)
        {
            gioHang = new Dictionary<string, int>();
        }

        
        if (gioHang.ContainsKey(khoa))
        {
            gioHang[khoa]++;
        }
        else
        {
            gioHang.Add(khoa, 1);
        }

        context.Session["GioHang"] = gioHang;

        context.Response.Write(
            "{\"ok\":true,\"soLuong\":" + gioHang[khoa] + "}");
    }

    public bool IsReusable
    {
        get { return false; }
    }
}