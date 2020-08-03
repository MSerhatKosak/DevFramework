using DevFramework.Core.CrossCuttingConcerns.Validation.Fluent;
using FluentValidation;
using PostSharp.Aspects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFramework.Core.Aspects.PostSharp
{
    [Serializable]
    public class FluentDationsAspect : OnMethodBoundaryAspect
    {
        Type _ValidatorType;
        public FluentDationsAspect(Type validtorType)
        {
            _ValidatorType = validtorType;
        }
        public override void OnEntry(MethodExecutionArgs args)
        {
            var validator =(IValidator)Activator.CreateInstance(_ValidatorType);
            var entityType = _ValidatorType.BaseType.GetGenericArguments()[0];//ProductValidator de 
            //base degerini alıyoruz
            var entities = args.Arguments.Where(t => t.GetType() == entityType);//burda degeri alıyoruz
            //degeri entitie eşitliyoruz //çalışıgımız metodda parametlerini geziyoruz burda 
            foreach (var entity in entities)
            {
                ValidatorTool.FluentValidate(validator, entity);//degerleri geziyoruz yazdıgımız metoda gonderiyoruz 
            }

        }
    }
}
