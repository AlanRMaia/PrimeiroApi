using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;

namespace Projeto.Application.Adapters
{
    public class AutoMapperConfig
    {
        //criando um método para registrar as classes
        //de mapeamento criadas (Profile)
        public static void Register()
        {
            //rotina de inicialização do AutoMapper
            Mapper.Initialize(
                map =>
                {
                    map.AddProfile<DomainEntityToModel>();
                    map.AddProfile<ModelToDomainEntity>();
                }
                );
        }
    }
}
