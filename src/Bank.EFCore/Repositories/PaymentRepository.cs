﻿using Bank.Domains.Payment;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Bank.EFCore.Repositories
{
    public class PaymentRepository : BaseRepository, IPaymentRepository
    {
        private readonly SqlDbContext dbContext;

        public PaymentRepository(SqlDbContext dbContext):base(dbContext)
        {
            this.dbContext = dbContext;
        }

        public Task<int> OrderCreateAsync(PayOrder order)
        {
            order.CreationTime = DateTime.Now;
            dbContext.Add(order);

            return dbContext.SaveChangesAsync();
        }

        public Task<int> OrderCloseAsync(PayOrder order)
        {
            order.CloseTime = DateTime.Now;
            order.Status = (int)PaymentStatus.Closed;
            //dbContext.Update(order);

            return dbContext.SaveChangesAsync();
        }

        public Task<int> OrderCancelAsync(PayOrder order)
        {
            order.CloseTime = DateTime.Now;
            order.Status = (int)PaymentStatus.Closed;
            //dbContext.Update(order);

            return dbContext.SaveChangesAsync();
        }

        public Task<PayOrder> OrderQueryLastAsync(long orderNo)
        {
            return dbContext.PayOrder.Where(e => e.IsDeleted == false && e.Status != (int)PaymentStatus.Closed && e.Status != (int)PaymentStatus.Canceled)
                .OrderByDescending(e => e.CreationTime).FirstOrDefaultAsync(e => e.OrderNo == orderNo);
        }
    }
}
