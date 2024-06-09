namespace WebCoreTask.Models
{
    public class SimpleIntrestModel
    {

        public decimal? PrincipalAmount { get; set; }
        public decimal? RateOfInterest { get; set; }
        public decimal? YearOfInvestment { get; set; }
        public decimal? SimpleInterest { get; set; }
        

        public void Calculate()
        {
            SimpleInterest = PrincipalAmount * RateOfInterest *YearOfInvestment/100;
        }
    }
}
