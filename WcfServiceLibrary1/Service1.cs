using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfServiceLibrary1
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени класса "Service1" в коде и файле конфигурации.
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class Service1 : IService1
    {
        List<string> europeTours = new List<string>();
        List<string> africaTours = new List<string>();

        public Service1()
        {
            europeTours.Add("Spain");
            europeTours.Add("Italia");
            europeTours.Add("England");
            europeTours.Add("France");
            europeTours.Add("Germany");

            africaTours.Add("Erypt");
            africaTours.Add("Ephiopia");
            africaTours.Add("Morocco");
            africaTours.Add("Libia");
            africaTours.Add("Sudan");

        }

        public List<string> GetEuropeTour()
        {
            return europeTours;
        }

        public List<string> GetAfricaTour()
        {
            return africaTours;
        }

        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public void RegBuy(bool ea, string name)
        {
            if (ea) europeTours.Remove(name);
            else    africaTours.Remove(name);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }
    }
}
