using System.Threading.Tasks;

namespace NetEaseMusicUI.Model
{
    public interface IDataService
    {
        Task<DataItem> GetData();
    }
}