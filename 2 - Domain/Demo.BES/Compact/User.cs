using Framework.Entity;

namespace Demo.Model
{
    /// <summary>
    /// User model domain class
    /// </summary>	
    public sealed class UserBES : BusinessEntityStructure
    {
        #region| Properties |

        public int ID { get; set; }
        public string Name { get; set; }

        #endregion

        #region| Constructor |

        public UserBES()
        {
            this.Map(nameof(ID));
            this.Map(nameof(Name));
        }

        #endregion
    }
}
