namespace WebCoreTask.Models
{
    public class DBViewModel
    {
        public IEnumerable<EmpModel> DataFromFirstDb { get; set; }
        public IEnumerable<EmpModel> DataFromSecondDb { get; set; }
    }
}
