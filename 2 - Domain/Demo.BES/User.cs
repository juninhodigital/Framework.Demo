using System.Collections.Generic;

using Framework.Entity;

namespace Demo.Model
{
    /// <summary>
    /// User model domain class
    /// </summary>	
    public sealed class User : BusinessEntityStructure
    {
        #region| Properties |

        public int ID { get; set; }
        public string Name { get; set; }
        public string Nickname { get; set; }
        public string RG { get; set; }
        public string CPF { get; set; }
        public int Age { get; set; }
        public bool Enabled { get; set; }

        public List<Address> Addresses { get; set; } = null;

        #endregion

        #region| Constructor |

        public User()
        {
            this.Map(nameof(ID));
            this.Map(nameof(Name));
            this.Map(nameof(Nickname));
            this.Map(nameof(RG));
            this.Map(nameof(CPF));
            this.Map(nameof(Enabled));
        }

        #endregion
    }
}
