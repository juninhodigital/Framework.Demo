namespace Demo.API
{
    internal static class CacheKeys
    {
        internal const string EXCHANGES                                       = "EXCHANGES";
        internal const string EXCHANGE_HOLIDAYS                               = "EXCHANGE_HOLIDAYS";
        internal const string EXCHANGE_HOLIDAYS_BY_COMMODITY_ID               = "EXCHANGE_HOLIDAYS_BY_COMMODITY_ID";
        internal const string EXCHANGE_HOLIDAYS_BY_COMMODITY_ID_AND_EXCHANGES = "EXCHANGE_HOLIDAYS_BY_COMMODITY_ID_AND_EXCHANGES";
        internal const string ENDPOINT_GROUPS                                 = "ENDPOINT_GROUPS";
        internal const string USER_GROUPS                                     = "USER_GROUPS";
        internal const string USERS                                           = "USERS";
        internal const string TOKENS                                          = "TOKENS";
        internal const string ENDPOINT_CONTAINER                              = "ENDPOINT_CONTAINER";
        internal const string MARKET_DATA_TYPES                               = "MARKET_DATA_TYPES";
        internal const string CALIBRATION_BY_DATE                             = "CALIBRATION_BY_DATE";

        internal static string WithId(string baseString, int id)
        {
            return $"{baseString}_{id.ToString()}";
        }
    }
}