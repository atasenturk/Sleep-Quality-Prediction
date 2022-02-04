using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SleepTrackerUI
{
    public class GetAdvice
    {
        private List<string> advices;
        public GetAdvice()
        {
            advices = new List<string>();
            advices.Add("Yatağın yeterince rahat değil :(. Yatağını değiştirmeyi denemelisin.");
            advices.Add("Uyumadan 3 saat önce yüksek kafein içmemeye özen göstermelisin.");
            advices.Add("Stresli ortamlardan uzak durmaya çalış, uyumadan önce kafanı boşaltmak için melisa veya papatya çayı içebilirsin :).");
            advices.Add("Uyumadan 1-2 saat önce ekranlardan uzak durabilirsin :)");
            advices.Add("Tebrikler, çok sağlıklı bir uyku geçirdiniz. Aynı şekilde devam et!");
        }
        public string getAdvice(float quality)
        {
            if (quality > 0.0 && quality < 20)
            {
                return advices[0];
            }

            else if (quality >= 20 && quality < 40)
            {
                return advices[1];
            }

            else if (quality >= 40 && quality < 60)
            {
                return advices[2];
            }

            else if (quality >= 60 && quality < 80)
            {
                return advices[3];
            }

            else if (quality >= 80 && quality <= 100)
            {
                return advices[4];
            }
            else return "Error";
        }
    }
}
