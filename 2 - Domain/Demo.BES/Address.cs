using Framework.Entity;

namespace Demo.Model
{
    /// <summary>
    /// Address model domain class
    /// </summary>	
    public sealed class Address : BusinessEntityStructure
    {
        #region| Properties |

        public int ID { get; set; }
        public string Street { get; set; }
        public string Neighborhood { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public int Number { get; set; }
        public bool Enabled { get; set; }

        #endregion

        #region| Constructor |

        public Address()
        {
            this.Map(nameof(ID));
            this.Map(nameof(Street));
            this.Map(nameof(Neighborhood));
            this.Map(nameof(City));
            this.Map(nameof(Country));
            this.Map(nameof(Number));            
            this.Map(nameof(Enabled));
        }

        #endregion
    }
}
