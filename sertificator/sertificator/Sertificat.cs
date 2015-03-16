using System;

namespace sertificator
{
    class Sertificat
    {
        public static int CurrentNumber{private set; get; }
        public int Numder { private set; get; }
        public int CodOfOrder { private set; get; }
        public DateTime DateOrder { private set; get; }
        public Decimal PriceOrder { private set; get; }
        public string Person { private set; get; }
        public string Phone { private set; get; }
        public string Email { private set; get; }

        public void Create()
        {
            Numder = CurrentNumber + 1;
            CurrentNumber++;
            Console.WriteLine();
        }
    }
}
