using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace sertificator
{
    class Services // 
    {
        private Dictionary<int, string> _listServices = new Dictionary<int, string>();
        private const string FilePath = "services.dat";
        private int _numberOfServices = 0;
        private string _company = "First Company";

        #region Функции


        public void WriteSettings()
        {
            RwDictionary.WriteDictionary(FilePath,_listServices,_company);
        }

        public void ReadSettings()
        {
           _listServices= RwDictionary.ReadDictionary(FilePath);
            _company = RwDictionary.Company;
            _numberOfServices = RwDictionary.NumberLines;
        }

        public bool ChangeSettings(int sw, int pararm1, string param2)
        {
            switch (sw)
            {
                case 1:  // смена компании
                    _company = param2;
                    return true;
                    break;

                case 2: // добавление сервиса
                    return AddService(pararm1, param2);
                    break;

                case 3: // Удаление сервиса
                    return DeleteService(pararm1);
                    break;

                case 4: // изменение сервиса
                    return ChangeService(pararm1, param2);
                    break;
            }
            return false;
        }

        public bool AddService(int number, string textSerice)
        {
            if (_listServices.ContainsKey(number))
            {
                return false;
            }
            else {
                _numberOfServices++;
                _listServices.Add(number, textSerice);
                return true;
            }
        } 

        public bool DeleteService(int number)
        {
            if (_listServices.ContainsKey(number))
            {
                _listServices.Remove(number);
                _numberOfServices--;
                return true;
            }
            else return false;
        }

        public bool ChangeService(int number, string textSerice)
        {
            if (!_listServices.ContainsKey(number))
                _numberOfServices++;
            _listServices.Add(number, textSerice);
            return true;
        } 
        #endregion

    }
}
