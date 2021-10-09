using CommandLine;

namespace crypto_cli.Options
{
    [Verb("get")]
    public class GetOptions
    { 
        [Option('c', "coin", Required = true, HelpText = "the name of the coin to return")]
        public string? Coin {  get; set; }

        [Option('p', "price", HelpText = "price of the coin")]
        public bool Price {  get; set; }    
    }
}
