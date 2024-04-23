using System;
using System.Collections.Generic;
using System.Text;
using static RopeDetection.CommonData.ModelEnums;

namespace RopeDetection.CommonData
{
    public static class ModelDictionary
    {
        public static Dictionary<string, string> Labels { get; } = new Dictionary<string, string>
        {
            ["AD"] = "обрывы наружных проволок",
            ["BD"] = "поверхностный износ",
            ["CD"] = "обрывы наружных проволок",
            // ["CD"] = "поверхностная коррозия",
            ["ED"] = "местное увеличение или уменьшение диаметра",
            ["FD"] = "разрыв прядей",
            ["GD"] = "волнистость",
            ["HD"] = "корзинообразность",
            ["JD"] = "раздавливание каната",
            ["KD"] = "выдавливание (отслоение) проволок, прядей или сердечника",
            ["LD"] = "сплющивание диаметра каната в результате механического воздействия",
            ["MD"] = "перекручивание",
            ["ND"] = "перегиб (залом)",
            ["QD"] = "температурное воздействие (электрический дуговой разряд или удар молнии)",
            ["PD"] = "дефекты уравновешивающих устройств, мест заделок их концов",
           // ["UW"] = "дефектов нет",
            ["UD"] = "дефектов нет"
        };

        public static Dictionary<ModelType, string> Scenario { get; } = new Dictionary<ModelType, string>
        {
            [ModelType.Classification] = "Классификация",
            [ModelType.Regression] = "Прогнозирование"
        };
    }
}
