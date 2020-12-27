using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConsoleTest
{
    public class RegexTelphone
    {
        public void aa() {
            string strPhone = @"地址是在燕18892456564山13492456564路378号~~~洋纱小区对面 传真051253581349董事长：15133652276 1513365227615133652276总经理15133652276535753577308办公室  53577311销售010-53574182财务53577318生产53577307食品协会53577309中";
            VaildPhone(strPhone);
        }

        /// <summary>
        /// 查询有效的手机号码或是电话号码
        /// </summary>
        /// <param name="strPhone"></param>
        private void VaildPhone(string strPhone)
        {
            MatchCollection matchList;
            Regex reBlock = new Regex(@"(\d{4}-|\d{3}-)?[\d]+");
            Regex reMobile = new Regex(@"^1(3[4-9]|5[012789]|8[78])\d{8}$");
            Regex reUnicom = new Regex(@"^1(3[0-2]|5[56]|8[56])\d{8}$");
            Regex reTelecom = new Regex(@"^18[0-9]\d{8}$");
            Regex reCDMA = new Regex(@"^1[35]3\d{8}$");
            Regex rePhone = new Regex(@"^((\d{4}-)?\d{7}|(\d{3}-)?\d{8})$");
            matchList = reBlock.Matches(strPhone);
            ArrayList PhoneArray = new ArrayList();
            for (int n = 0; n < matchList.Count; n++)
            {
                if (getValue(reMobile, matchList[n].Value) != "")
                {
                    PhoneArray.Add(getValue(reMobile, matchList[n].Value));
                    continue;
                }
                if (getValue(reUnicom, matchList[n].Value) != "")
                {
                    PhoneArray.Add(getValue(reUnicom, matchList[n].Value));
                    continue;
                }
                if (getValue(reTelecom, matchList[n].Value) != "")
                {
                    PhoneArray.Add(getValue(reTelecom, matchList[n].Value));
                    continue;
                }
                if (getValue(reCDMA, matchList[n].Value) != "")
                {
                    PhoneArray.Add(getValue(reCDMA, matchList[n].Value));
                    continue;
                }
                if (getValue(rePhone, matchList[n].Value) != "")
                {
                    PhoneArray.Add(getValue(rePhone, matchList[n].Value));
                    continue;
                }
            }
            foreach (var item in PhoneArray)
            {
                Console.WriteLine(item);
            }
            Console.Read();
        }
        /// <summary>
        /// 获得验证结果
        /// </summary>
        /// <param name="Reg">匹配的正则</param>
        /// <param name="Info">匹配的信息</param>
        /// <returns></returns>
        private string getValue(Regex Reg, string Info)
        {
            if (Reg.Match(Info).Success)
            {
                return Reg.Match(Info).Value;
            }
            else
            {
                return "";
            }
        }
    }
}
