using Framework.Entity;

namespace Demo.Model
{
    /// <summary>
    /// Client model domain class
    /// </summary>	
    public sealed class ClientCompact : BusinessEntityStructure
    {
        #region| Properties |

        public int ID { get; set; }
        public string Name { get; set; }

        #endregion

        #region| Constructor |

        public ClientCompact()
        {
            this.Map(nameof(ID));
            this.Map(nameof(Name));
        }

        #endregion
    }
}
