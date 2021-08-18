using System;
using System.Linq;
using System.Threading.Tasks;
using FluentPOS.Shared.Core.Entities;
using FluentPOS.Shared.Core.IntegrationServices.Application;
using FluentPOS.Shared.Core.Interfaces;

namespace FluentPOS.Shared.Infrastructure.Services
{
    public class EntityReferenceService : IEntityReferenceService
    {
        private readonly IApplicationDbContext _context;

        public EntityReferenceService(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<string> TrackAsync(string entityName)
        {
            var referenceNumber = string.Empty;
            var monthYearString = DateTime.Now.ToString("MMyy");
            var recordExists = _context.EntityReferences.Any(a => a.Entity == entityName && a.MonthYearString == monthYearString);
            if (recordExists)
            {
                var record = _context.EntityReferences.Where(a => a.Entity == entityName && a.MonthYearString == monthYearString).FirstOrDefault();
                if (record != null)
                {
                    record.Increment();
                    _context.EntityReferences.Update(record);
                    referenceNumber = GenerateReferenceNumber(entityName, record.Count, monthYearString);
                }
            }
            else
            {
                var record = new EntityReference(entityName);
                _context.EntityReferences.Add(record);
                referenceNumber = GenerateReferenceNumber(entityName, record.Count, monthYearString);
            }

            await _context.SaveChangesAsync();
            return referenceNumber;
        }

        private string GenerateReferenceNumber(string entity, int count, string monthYearString)
        {
            return $"{entity.First()}-{monthYearString}-{count.ToString().PadLeft(5, '0')}";
        }
    }
}