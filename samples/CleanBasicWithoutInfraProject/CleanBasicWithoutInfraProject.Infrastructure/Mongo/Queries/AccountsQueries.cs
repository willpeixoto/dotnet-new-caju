﻿namespace CleanBasicWithoutInfraProject.Infrastructure.Mongo.Queries
{
    using CleanBasicWithoutInfraProject.Application.Queries;
    using CleanBasicWithoutInfraProject.Application.Results;
    using MongoDB.Driver;
    using System;
    using System.Threading.Tasks;
    using CleanBasicWithoutInfraProject.Application;
    using CleanBasicWithoutInfraProject.Domain.Accounts;

    public class AccountsQueries : IAccountsQueries
    {
        private readonly MongoContext mongoDB;
        private readonly IResultConverter mapper;

        public AccountsQueries(MongoContext mongoDB, IResultConverter mapper)
        {
            this.mongoDB = mongoDB;
            this.mapper = mapper;
        }

        public async Task<AccountResult> GetAccount(Guid accountId)
        {
            Account data = await mongoDB
                .Accounts
                .Find(e => e.Id == accountId)
                .SingleOrDefaultAsync();

            if (data == null)
                throw new AccountNotFoundException($"The account {accountId} does not exists or is not processed yet.");

            AccountResult accountResult = this.mapper.Map<AccountResult>(data);

            return accountResult;
        }
    }
}