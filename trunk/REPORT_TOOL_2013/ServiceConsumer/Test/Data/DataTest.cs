using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ServiceConsumer.Test.Data
{
    public class DataTest
    {
        public static Dictionary<string,TemplateModelTest> lstDataTest = new Dictionary<string,TemplateModelTest>();
        private static bool isInit = false;
        public static void initDataTest()
        {
            if (isInit)
            {
                return;
            }
            TemplateModelTest vnIndex = new TemplateModelTest();
            vnIndex.lanTangGiam = "lần thứ 2";
            vnIndex.giaTri = "452";
            vnIndex.muc = "Undefined";
            vnIndex.phanTramThayDoi = "5%";
            vnIndex.diemTangGiam = "Tăng 10 điểm";
            vnIndex.tangGiam = "3";

            TemplateModelTest hnx = new TemplateModelTest();
            hnx.lanTangGiam = "lần thứ 5";
            hnx.giaTri = "252";
            hnx.muc = "Undefined";
            hnx.phanTramThayDoi = "tăng 10%";
            hnx.diemTangGiam = "Tăng 15 điểm";
            hnx.tangGiam = "4";

            TemplateModelTest vn30 = new TemplateModelTest();
            vn30.lanTangGiam = "lần thứ 6";
            vn30.giaTri = "322";
            vn30.muc = "Undefined";
            vn30.phanTramThayDoi = "tăng 15%";
            vn30.diemTangGiam = "Tăng 30 điểm";
            vn30.tangGiam = "2";

            lstDataTest.Add("VNINDEX",vnIndex);
            lstDataTest.Add("HNX",hnx);
            lstDataTest.Add("VN30",vn30);
            isInit = true;
        }
    }
}
