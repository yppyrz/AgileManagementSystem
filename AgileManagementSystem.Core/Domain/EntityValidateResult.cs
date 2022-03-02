using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgileManagementSystem.Core.Domain
{
    public class EntityValidateResult
    {
        /// <summary>
        /// Entity'nin kayıt olmadan önce geçtiği kontrollerin sonucunu tutar.
        /// </summary>
        public bool IsValid { get; set; }

        /// <summary>
        /// Eğer entity validasyon sırasında bir hata alırsa, hata mesajı buraya eklenir.
        /// </summary>
        public List<string> ErrorMessage { get; set; } = new List<string>();
    }
}
