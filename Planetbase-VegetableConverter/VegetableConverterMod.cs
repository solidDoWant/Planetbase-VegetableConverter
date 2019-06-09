using System.Linq;
using Planetbase;
using PlanetbaseFramework;

namespace VegetableConverter
{
    public class VegetableConverterMod : ModBase
    {
        public override string ModName { get; } = "VegetableConverter";

        public override void Init()
        {
            var converterInstance = (ComponentType)new VegetableConverter();

            //Register the component
            var componentTypeList = TypeList<ComponentType, ComponentTypeList>.getInstance();
            componentTypeList.add(converterInstance);

            //Add the component to the biodome. Unfortunately this also must be done with reflection
            var bioDome = TypeList<ModuleType, ModuleTypeList>.find<ModuleTypeBioDome>();

            var newComponentList = bioDome.mComponentTypes.ToList();
            newComponentList.Add(converterInstance);
            bioDome.mComponentTypes = newComponentList.ToArray();
        }
    }
}
