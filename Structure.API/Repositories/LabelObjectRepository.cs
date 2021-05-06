using MongoDB.Driver;
using Structure.API.Models;
using Structure.Domain.Shared.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Linq.Dynamic.Core;
using MongoDB.Driver.Linq;
using Structure.Domain.Shared.Extensions;

namespace Structure.Domain.LabelObjects
{
    public class LabelObjectRepository : ILabelObjectRepository
    {
        private readonly IMongoCollection<LabelObject> _labels;

        public LabelObjectRepository(IDataBaseSettings dataBaseSettings)
        {
            var client = new MongoClient(dataBaseSettings.ConnectionString);
            var database = client.GetDatabase(dataBaseSettings.DatabaseName);

            _labels = database.GetCollection<LabelObject>(dataBaseSettings.LabelObjectCollectionName);
        }
        public async Task DeleteAsync(Guid id)
        {
             await _labels.DeleteOneAsync(lo=>lo.Id==id);
        }

        public async Task<LabelObject> GetAsync(Guid id)
        {
            var query = await _labels.FindAsync(lo => lo.Id == id);
            return await query.FirstOrDefaultAsync();
        }

        public IQueryable<LabelObject> ApplyFilter(
            IQueryable<LabelObject> query,
            string filterText,
            int? labelObjectIdMin = null,
            int? labelObjectIdMax = null,
            string labelCaption = null,
            TextCssClass? textCssClass = null,
            BackgroundCssClass? backgroundCssClass = null)
        {
            if (!string.IsNullOrWhiteSpace(filterText))
                query.Where(e=>e.LabelCaption.Contains(filterText));
            if (labelObjectIdMin.HasValue)
                query.Where(e=>e.LabelObjectId>=labelObjectIdMin);
            if (labelObjectIdMax.HasValue)
                query.Where(e => e.LabelObjectId <= labelObjectIdMax);
            if (!string.IsNullOrWhiteSpace(labelCaption))
                query.Where(e => e.LabelCaption.Contains(labelCaption));
            if (textCssClass.HasValue)
                query.Where(e => e.TextCssClass == textCssClass);
            if (backgroundCssClass.HasValue)
                query.Where(e => e.BackgroundCssClass == backgroundCssClass);

            return query;
        }

        public async Task<long> GetCountAsync(string filterText = null, int? labelObjectIdMin = null, int? labelObjectIdMax = null, string labelCaption = null, 
            TextCssClass? textCssClass = null,BackgroundCssClass? backgroundCssClass = null, CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter(_labels.AsQueryable(), filterText, labelObjectIdMin, labelObjectIdMax, labelCaption, textCssClass, backgroundCssClass);

            return  query.AsQueryable().LongCount();
        }

        public async Task<List<LabelObject>> GetListAsync(string filterText = null, int? labelObjectIdMin = null, 
            int? labelObjectIdMax = null, string labelCaption = null, TextCssClass? textCssClass = null, 
            BackgroundCssClass? backgroundCssClass = null,
            string sorting = null,
            int maxResultCount = int.MaxValue,
            int skipCount = 0, 
            CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter(_labels.AsQueryable(), filterText, labelObjectIdMin, labelObjectIdMax, labelCaption, textCssClass, backgroundCssClass);
            query.OrderBy(string.IsNullOrWhiteSpace(sorting) ? LabelObjectConsts.GetDefaultSorting(false) : sorting);

            return  query.As<IMongoQueryable<LabelObject>>()
                .PageBy<LabelObject, IMongoQueryable<LabelObject>>(skipCount, maxResultCount)
                .ToList();
        }

        public async Task<LabelObject> InsertAsync(LabelObject labelObject, bool autoSave)
        {
            await _labels.InsertOneAsync(labelObject);
            var query = _labels.AsQueryable();
            return query.FirstOrDefault(l=>l.Id==labelObject.Id);
            //labelObject nu are un Id inainte de a fi introdusa in baza de date??????????????????????

        }

       

        public async Task<LabelObject> UpdateAsync(LabelObject labelObject)
        {
            await _labels.ReplaceOneAsync(lb=>lb.Id==labelObject.Id,labelObject);
            var query = _labels.AsQueryable<LabelObject>();
            return query.FirstOrDefault(e => e.Id == labelObject.Id);

        }
    }
}
