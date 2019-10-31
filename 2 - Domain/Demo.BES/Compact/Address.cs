using Framework.Entity;

namespace Demo.Model
{
    /// <summary>
    /// Address model domain class
    /// </summary>	
    public class AddressCompact: BusinessEntityStructure
    {
        #region| Properties |

        public int ID { get; set; }
        public string Street { get; set; }
        public bool Enabled { get; set; }

        #endregion

        #region| Constructor |

        public AddressCompact()
        {
            this.Map(nameof(ID));
            this.Map(nameof(Street));
            this.Map(nameof(Enabled));
        }

        #endregion
    }
}
