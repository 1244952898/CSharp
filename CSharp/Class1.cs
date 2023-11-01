using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp
{
    internal class Class1:IFormatProvider
    {
        public string Name1 { get; set; }
        public string Name2 { get; set; }
        public string Name3 { get; set; }
        public string Name4 { get; set; }
        public string Name5 { get; set; }

        public object GetFormat(Type formatType)
        {
            return null;
            //onSearchDialog事件

            //var Obj = new Object();
            //let item = inDom;
            //let itemtype = inDom.getAttribute("type");
            ////多数据源搜索条件限制
            //if (itemtype == 'hs_pco_item')
            //{
            //    item.setAttribute("where", "([hs_pco_item].itemtype ='DF373D3D2CC1462D852C2BD420CCF5E2' and [hs_pco_item].state='Released') or ([hs_pco_item].itemtype ='02184EDAA80D499CB6EC94B159966DBE' and [hs_pco_item].state='Active') or ([hs_pco_item].itemtype ='56450F8A81424CB5B3C86DDF33F2D979' and [hs_pco_item].state='Released') or ([hs_pco_item].itemtype ='02184EDAA80D499CB6EC94B159966DBE' and [hs_pco_item].state='Completed')");
            //}
            ////单个对象类条件限制
            //else if (itemtype == 'hs pi')
            //{
            //    Obj["state"] = { filterValue: "Released" ,isFilterFixed: true};
            //}
            //else if (itemtype == 'Product')
            //{
            //    Obj["state"] = { filterValue: "Released" ,isFilterFixed: true};
            //}
            //else if (itemtype == 'Project')
            //{
            //    Obj["state"] = { filterValue: "Active" ,isFilterFixed: true};
            //}

            //return Obj;
        }
    }
}
