namespace JWT.Extensions.Entity
{
    /// <summary>
    /// jwt base payload
    /// </summary>
    public class Payload
    {
        /// <summary>
        /// subject
        /// </summary>
        public string sub { get; set; }

        /// <summary>
        /// issuer
        /// </summary>
        public string iss { get; set; }

        /// <summary>
        /// audience
        /// </summary>
        public string aud { get; set; }

        /// <summary>
        /// expiration time
        /// </summary>
        public long exp { get; set; }

        public Payload()
        { }

        public Payload(string sub, string iss, string aud, long exp)
        {
            this.sub = sub;
            this.iss = iss;
            this.aud = aud;
            this.exp = exp;
        }
    }
}
