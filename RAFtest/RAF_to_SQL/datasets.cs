using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RAFtest
{
	class datasets
	{
		public class searchParameter
		{
			public string searchKey{get;set;}
			public string searchVal{get;set;}
		}
		public class vendors
		{
			public int id { get; set; }
			public string v_code { get; set; }
			public string business_name { get; set; }
			public string address_1 { get; set; }
			public string address_2 { get; set; }
			public string city_state_zip { get; set; }
			public string fax_number { get; set; }
			public string terms { get; set; }
			public string order_contact { get; set; }
			public string order_email { get; set; }
			public string order_email_cc { get; set; }
			public string order_phone { get; set; }
			public string account_contact { get; set; }
			public string account_email { get; set; }
			public string account_phone { get; set; }
			public string quality_contact { get; set; }
			public string quality_email { get; set; }
			public string quality_phone { get; set; }
			public string shipping_contact { get; set; }
			public string shipping_email { get; set; }
			public string shipping_phone { get; set; }
		}
		public class sample_data
		{
			public vendors get_sample_vendor()
			{
				vendors vendor_tester = new vendors();
				vendor_tester.id = 0;
				vendor_tester.v_code = "QUCAST";
				vendor_tester.business_name = "QUALITY CASTINGS";
				vendor_tester.address_1 = "1908 MACARTHUR RD";
				vendor_tester.address_2 = "";
				vendor_tester.city_state_zip = "WAUKESHA WI 53188";
				vendor_tester.fax_number = "414-475-6539";
				vendor_tester.terms = "";
				vendor_tester.order_contact = "RANDY HARRINGTON";
				vendor_tester.order_email = "willf@fsasales.com";
				vendor_tester.order_email_cc = "262-442-7565";
				vendor_tester.order_phone = "";
				vendor_tester.account_contact = "";
				vendor_tester.account_email = "";
				vendor_tester.account_phone = "";
				vendor_tester.quality_contact = "test quality contact";
				vendor_tester.quality_email = "";
				vendor_tester.quality_phone = "";
				vendor_tester.shipping_contact = "";
				vendor_tester.shipping_email = "";
				vendor_tester.shipping_phone = "test shipping phone";
				return vendor_tester;
			}
		}
	}
}