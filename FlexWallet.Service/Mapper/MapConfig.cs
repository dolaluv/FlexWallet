using AutoMapper;
using FlexWallet.Abstractions.Models;
using FlexWallet.Abstractions.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlexWallet.Mapper
{
    public class MapConfig
    {

        public static MapperConfiguration RegristerMapper()
        {

            var mapConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<WalletUserRegister, WalletUser>().ReverseMap();
                config.CreateMap<WalletFundTransferDto, WalletFundTransaction>().ReverseMap();

            });

            return mapConfig;
        }

    }
}
