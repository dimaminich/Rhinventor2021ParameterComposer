using System;
using System.Collections.Generic;

using Grasshopper.Kernel;
using Rhino.Geometry;


namespace Rhinventor2021ParameterComposer
{
    public class Rhinventor2021ParameterComposerComponent : GH_Component
    {
        private static System.Reflection.Assembly ass = System.Reflection.Assembly.GetExecutingAssembly();
        public Rhinventor2021ParameterComposerComponent()
          : base("RhinventorParameterComposer", "rhiparam",
              $"RhinventorParameterComposer {ass.GetName().Version.ToString()} (Created by Dimitrij Minich). Compose parameters",
              "Rhinventor", "Parameters")
        {
        }

        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddTextParameter("parameterKey", "K", "Set parameter key", GH_ParamAccess.list);
            pManager.AddTextParameter("parameterValue", "V", "Set parameter value", GH_ParamAccess.list);
        }

        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddGenericParameter("composedParameter", "P", "Composed parameters", GH_ParamAccess.item);
        }

        protected override void SolveInstance(IGH_DataAccess DA)
        {
            List<string> parameterKeys = new List<string>();
            if (!DA.GetDataList(0, parameterKeys)) return;

            List<string> parameterValues = new List<string>();
            if (!DA.GetDataList(1, parameterValues)) return;

            if (parameterKeys.Count != parameterValues.Count) throw new ArgumentException("Length of parameter keys and values is different");

            Dictionary<string, string> composedParameters = new Dictionary<string, string>();
            for (int i = 0; i < parameterKeys.Count; i++)
            {
                string key = parameterKeys[i];
                string value = parameterValues[i];
                composedParameters.Add(key, value);
            }

            DA.SetData(0, composedParameters);
        }

        protected override System.Drawing.Bitmap Icon
        {
            get
            {
                return Resources.Rhinventor2021ParameterComposer24;
            }
        }

        public override Guid ComponentGuid
        {
            get { return new Guid("5ee1453a-bc3e-4ea5-bf9d-254d9fdac7a8"); }
        }
    }
}
