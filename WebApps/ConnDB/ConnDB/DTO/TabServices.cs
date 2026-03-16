using AutoMapper;
using ExcelToDatabaseAPI.Context;
using ExcelToDatabaseAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ExcelToDatabaseAPI.DTO
{
    public interface ITabService
    {
        Task<IEnumerable<tab>> GetTabsAsync();
    }
    public class TabServices : ITabService
    {
        private readonly IMapper mapper;

        public TabServices(AppDbContext appDb,IMapper Mapper)
        {
            AppDb = appDb;
            this.mapper = Mapper;
        }

        public AppDbContext AppDb { get; }

        public async Task<IEnumerable<tab>> GetTabsAsync()
        {

            var tabs = await AppDb.Tab.Include(x=>x.Customer).ToListAsync()/*.Include(x=>x.customer)*/;
            return (IEnumerable<tab>)mapper.Map<TabDto>(tabs) ;
           
        }
    }
}
