using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RAFtest
{
	class dataSwitches
	{
		public string vendorSqlSwitch(string sqlCol, datasets.vendors v)
		{
			switch (sqlCol)
			{
				case "id":
					return v.id.ToString();
				case "v_code":
					return v.v_code;
				case "business_name":
					return v.business_name;
				case "address_1":
					return v.address_1;
				case "address_2":
					return v.address_2;
				case "city_state_zip":
					return v.city_state_zip;
				case "fax_number":
					return v.fax_number;
				case "terms":
					return v.terms;
				case "order_contact":
					return v.order_contact;
				case "order_email":
					return v.order_email;
				case "order_email_cc":
					return v.order_email_cc;
				case "order_phone":
					return v.order_phone;
				case "account_contact":
					return v.account_contact;
				case "account_email":
					return v.account_email;
				case "account_phone":
					return v.account_phone;
				case "quality_contact":
					return v.quality_contact;
				case "quality_email":
					return v.quality_email;
				case "quality_phone":
					return v.quality_phone;
				case "shipping_contact":
					return v.shipping_contact;
				case "shipping_email":
					return v.shipping_email;
				case "shipping_phone":
					return v.shipping_phone;
				default:
					return "";
			}
		}
		public datasets.vendors vendorSwitch(int i, string rawData, datasets.vendors v)
		{
			switch (i)
			{
				case 1:
					v.v_code = rawData;
					return v;
				case 2:
					v.business_name = rawData;
					return v;
				case 3:
					v.address_1 = rawData;
					return v;
				case 4:
					v.address_2 = rawData;
					return v;
				case 5:
					v.city_state_zip = rawData;
					return v;
				case 6:
					v.fax_number = rawData;
					return v;
				case 7:
					v.terms = rawData;
					return v;
				case 8:
					v.order_contact = rawData;
					return v;
				case 9:
					v.order_email = rawData;
					return v;
				case 10:
					v.order_email_cc = rawData;
					return v;
				case 11:
					v.order_phone = rawData;
					return v;
				case 12:
					v.account_contact = rawData;
					return v;
				case 13:
					v.account_email = rawData;
					return v;
				case 14:
					v.account_phone = rawData;
					return v;
				case 15:
					v.quality_contact = rawData;
					return v;
				case 16:
					v.quality_email = rawData;
					return v;
				case 17:
					v.quality_phone = rawData;
					return v;
				case 18:
					v.shipping_contact = rawData;
					return v;
				case 19:
					v.shipping_email = rawData;
					return v;
				case 20:
					v.shipping_phone = rawData;
					return v;
				default:
					return v;
			}
		}
	}
}
