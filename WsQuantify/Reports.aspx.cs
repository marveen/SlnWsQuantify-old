using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;
using ClosedXML.Excel;
using System.IO;
using System.Data;



namespace WsQuantify
{
    public partial class Reports : System.Web.UI.Page
    {

        DataSet DsetReport = new DataSet();
        WsQuantify.WebServiceQuantify Wsneed = new WebServiceQuantify();

        String StrJsonReport = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            //Response.Write(StrJsonReport);
        }


        private DataTable GetDtArea()
        {
            DataTable DtSalida = new DataTable();

            DtSalida.TableName = "Area";

            //DataColumn idColumn = new DataColumn("id", typeof(string));
            DataColumn colCodigo = new DataColumn("Codigo", typeof(string));
            DataColumn colDescription = new DataColumn("Description", typeof(string));
            DataColumn colLength = new DataColumn("Length", typeof(int));
            DataColumn colWidth = new DataColumn("Width", typeof(int));
            DataColumn colM2 = new DataColumn("M2", typeof(float));

            DtSalida.Columns.Add(colCodigo);
            DtSalida.Columns.Add(colDescription);
            DtSalida.Columns.Add(colLength);
            DtSalida.Columns.Add(colWidth);
            DtSalida.Columns.Add(colM2);


            //DataRow TempRow = DtSalida.NewRow();
            //TempRow["Codigo"] = "cod001";
            //TempRow["Description"] = "cualquier wea";
            //TempRow["Length"] = 100;
            //TempRow["Width"] = 100;
            //TempRow["M2"] = 2.3;
            //DtSalida.Rows.Add(TempRow);

            DtSalida.Rows.Add(new Object[] { "1AAC GIZ.001", "GANCHO DE IZAJE PANEL ALLSTEEL", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1AAC MEN.003", "MENSULA DE MURO TREPANTE", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1AAC MEN.006", "MENSULA DE ACCESO ALLSTEEL", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1AAC MEN.008", "MENSULA DE MURO TREPANTE HD", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1AAC MEN.009", "PLATAFORMA COLGANTE PARA MENSULA HD", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1AAC MEN.010", "MENSULA COLGANTE HD", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1AAC PAL.001", "PALET", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1AAC PAL.002", "PALET C/REJILLA", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1AAC SAJ.001", "SOPORTE AJUSTABLE", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1AAC SPV.001", "SOPORTE VOLADIZO 900", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1AAP AHD.195", "APLOMADOR HD 1950-2800", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1AAP AHD.370", "APLOMADOR HD 3700-4500", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1AAP AHD.450", "APLOMADOR HD 4500-5400", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1AAP APP.002", "APLOMADOR ALL STEEL 2000-3400", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1AAP APP.003", "APLOMADOR ALL STEEL 1000-1500", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1AAP ED3.500", "EXTENSOR APLOMADOR MAGNUM 3500", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1AAP ED4.500", "EXTENSOR APLOMADOR MAGNUM 4500", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1AAP EX3.500", "EXTENSOR APLOMADOR ALLSTEEL 3500", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1AAP EX4.500", "EXTENSOR APLOMADOR ALLSTEEL 4500", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1AAP HEM.001", "HEMBRA APLOMADOR", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1AAZ CVI.002", "ALZAPRIMA FONDO VIGA 2000-3400", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1AAZ CVI.005", "ALZAPRIMA FONDO VIGA 1750-3000", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1AAZ LSA.002", "ALZAPRIMA LOSA 2000-3200", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1AAZ LSA.003", "ALZAPRIMA LOSA 2600-3900", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1AAZ LSA.005", "ALZAPRIMA LOSA N.5 G. 1750-3000", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1ACO CCA.001", "CLIP PARA CANAL", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1ACO CLI.001", "CLIP UNIVERSAL VIGA ALUMINIO", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1ACO CLI.002", "CLIP DOBLE CANAL PLEGADA", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1ACO CLI.003", "CLIP VIGA ALUMINIO", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1ACO CLI.005", "CLIP VIGA ALUMINIO H=150", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1ACO CME.012", "CONO METALICO M12", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1ACO CME.020", "CONO METALICO M20", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1ACO CME.024", "CONO METALICO M24", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1ACO CON.001", "CONECTORES L/D", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1ACO COP.001", "COPLA GIRATORIA 50X50", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1ACO COP.003", "COPLA GIRATORIA COMPLETA CON CU�A", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1ACO CTR.020", "CONO TREPANTE M20", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1ACO CTR.034", "CONO TREPANTE 3/4", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1ACO CTR.045", "CONO TREPANTE C/HILO 17MMX450", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1ACO CTR.050", "CONO TREPANTE C/HILO 17MM X 1050", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1ACO CTU.001", "CLIP PARA TUBO", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1ACO EEE.040", "ESQUINERO EXTERIOR 650X50X50", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1ACO EI0.060", "ESQUINERO INTERIOR 600X150X150", 600, 300, 0.18 });
            DtSalida.Rows.Add(new Object[] { "1ACO EI0.075", "ESQUINERO INTERIOR 750X150X150", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1ACO EI0.080", "ESQUINERO INTERIOR 800X150X150", 800, 300, 0.24 });
            DtSalida.Rows.Add(new Object[] { "1ACO EI0.090", "ESQUINERO INTERIOR 900X150X150", 900, 300, 0.27 });
            DtSalida.Rows.Add(new Object[] { "1ACO EI1.200", "ESQUINERO INTERIOR 1200X150X150", 1200, 300, 0.36 });
            DtSalida.Rows.Add(new Object[] { "1ACO EI2.400", "ESQUINERO INTERIOR 2400X150X150", 2400, 300, 0.72 });
            DtSalida.Rows.Add(new Object[] { "1ACO EI2.402", "ESQUINERO INTERIOR 2400X200X150", 2400, 350, 0.84 });
            DtSalida.Rows.Add(new Object[] { "1ACO EIE.016", "ESQUINERO INTERIOR 2400X200X200", 2400, 400, 0.96 });
            DtSalida.Rows.Add(new Object[] { "1ACO EIL.006", "ESQUINERO INT. DE LOSA 600X150X150", 600, 300, 0.18 });
            DtSalida.Rows.Add(new Object[] { "1ACO ET2.400", "ESQUINERO EXTERIOR 2400X50X50 CON TUERCA", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1ACO EX0.600", "ESQUINERO EXTERNO 600X50X50", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1ACO EX0.800", "ESQUINERO EXTERNO 800X50X50", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1ACO EX0.900", "ESQUINERO EXTERNO 900X50X50", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1ACO EX1.200", "ESQUINERO EXTERIOR 1200X50X50", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1ACO EX2.400", "ESQUINERO EXTERIOR 2400X50X50", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1ACO GOL.002", "GOLILLA 75X75X6", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1ACO GOL.008", "GOLILLA PRESION 5/8", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1ACO GOL.L01", "GOLILLA L", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1ACO GRA.B01", "GRAMPA B", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1ACO GRA.B02", "GRAMPA B PASADOR CAUTIVO", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1ACO GRA.B03", "GRAMPA B C/HILO RAPIDO", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1ACO GRA.C01", "GRAMPA C", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1ACO GRA.C03", "GRAMPA C C/HILO RAPIDO", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1ACO JCU.002", "CUÑA HEMBRA", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1ACO JCU.003", "CUÑA MACHO", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1ACO JCU.005", "JUEGO DE CU�AS PAREADAS", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1ACO JPB.002", "PLACA", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1ACO JPB.003", "BANDA 50X50", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1ACO MEN.007", "MENSULA DE ANTEPECHO", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1ACO PAD.017", "FORM PAD 150X150 D17", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1ACO PAD.021", "FORM PAD 150X150 D21", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1ACO PER.010", "PERNO M12X80", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1ACO PER.040", "PERNO M20 X 40 GRADO 5", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1ACO SES.001", "SOPORTE ESQUINERO", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1ACO SES.002", "SOPORTE ESQUINERO C/PERFIL", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1ACO TC0.001", "TUERCA 1/2", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1ACO TC0.004", "TUERCA 5/8", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1ACO TCA.012", "TUERCA DE TIRANTE 12", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1ACO TCA.M12", "TUERCA M12X1.75", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1ACO TGO.012", "TUERCA TIRANTE C/GOLILLA 12", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1ACO TI0.050", "TIRANTE 12 X 500", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1ACO TI0.250", "TIRANTE 12 X 250", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1ACO TI0.600", "TIRANTE 12 X 600", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1ACO TI1.000", "TIRANTE 12 X 1000", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1ACO TI1.500", "TIRANTE 12 X 1500", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1ACO TI2.000", "TIRANTE 12 X 2000", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1ACO TI2.500", "TIRANTE 12 X 2500", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1ACO TI3.000", "TIRANTE 12 X 3000", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1ACO TTP.350", "TIRANTE 12 X 350 C/TOPE", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1ACO TTP.500", "TIRANTE 12 X 500 C/TOPE", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1ACO TTP.750", "TIRANTE 12 X 750 C/TOPE", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1ADP 001.000", "DOBLE PERFIL 1000", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1ADP 001.500", "DOBLE PERFIL 1500", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1ADP 002.000", "DOBLE PERFIL 2000", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1ADP 002.500", "DOBLE PERFIL 2500", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1ADP 003.000", "DOBLE PERFIL 3000", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1ADP 003.500", "DOBLE PERFIL 3500", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1ADP 004.000", "DOBLE PERFIL 4000", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1ADP 004.500", "DOBLE PERFIL 4500", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1APE 060.140", "PANEL MURO TAPA ALL STEEL 600X140", 600, 140, 0.084 });
            DtSalida.Rows.Add(new Object[] { "1APE 090.120", "PANEL MURO TAPA ALL STEEL 900X120", 900, 120, 0.108 });
            DtSalida.Rows.Add(new Object[] { "1APE 090.140", "PANEL MURO TAPA ALL STEEL 900X140", 900, 140, 0.126 });
            DtSalida.Rows.Add(new Object[] { "1APE 090.180", "PANEL MURO TAPA ALL STEEL 900X180", 900, 180, 0.162 });
            DtSalida.Rows.Add(new Object[] { "1APE 120.120", "PANEL MURO TAPA ALL STEEL 1200X120", 1200, 120, 0.144 });
            DtSalida.Rows.Add(new Object[] { "1APE 120.140", "PANEL MURO TAPA ALL STEEL 1200X140", 1200, 140, 0.168 });
            DtSalida.Rows.Add(new Object[] { "1APE 120.170", "PANEL MURO TAPA ALL STEEL 1200X170", 1200, 170, 0.204 });
            DtSalida.Rows.Add(new Object[] { "1APE 120.180", "PANEL MURO TAPA ALL STEEL 1200X180", 1200, 180, 0.216 });
            DtSalida.Rows.Add(new Object[] { "1APE 240.120", "PANEL MURO TAPA ALL STEEL 2400X120", 2400, 120, 0.288 });
            DtSalida.Rows.Add(new Object[] { "1APE 240.140", "PANEL MURO TAPA ALL STEEL 2400X140", 2400, 140, 0.336 });
            DtSalida.Rows.Add(new Object[] { "1APE 240.170", "PANEL MURO TAPA ALL STEEL 2400X170", 2400, 170, 0.408 });
            DtSalida.Rows.Add(new Object[] { "1APE 240.180", "PANEL MURO TAPA ALL STEEL 2400X180", 2400, 180, 0.432 });
            DtSalida.Rows.Add(new Object[] { "1APE 900.170", "PANEL MURO TAPA ALL STEEL 900X170", 900, 170, 0.153 });
            DtSalida.Rows.Add(new Object[] { "1APF 090.600", "PANEL FLEX 900X600", 900, 600, 0.54 });
            DtSalida.Rows.Add(new Object[] { "1APF 120.600", "PANEL FLEX 1200X600", 1200, 600, 0.72 });
            DtSalida.Rows.Add(new Object[] { "1APF 240.600", "PANEL FLEX 2400X600", 2400, 600, 1.44 });
            DtSalida.Rows.Add(new Object[] { "1APL 060.150", "PANEL LOSA ALL STEEL 600X150", 600, 150, 0.09 });
            DtSalida.Rows.Add(new Object[] { "1APL 060.200", "PANEL LOSA ALL STEEL 600X200", 600, 200, 0.12 });
            DtSalida.Rows.Add(new Object[] { "1APL 070.400", "PANEL LOSA ALL STEEL 700X400", 700, 400, 0.28 });
            DtSalida.Rows.Add(new Object[] { "1APL 070.600", "PANEL LOSA ALL STEEL 700X600", 700, 600, 0.42 });
            DtSalida.Rows.Add(new Object[] { "1APL 080.200", "PANEL LOSA ALL STEEL 800X200", 800, 200, 0.16 });
            DtSalida.Rows.Add(new Object[] { "1APL 090.140", "PANEL LOSA ALL STEEL 900X140", 900, 140, 0.126 });
            DtSalida.Rows.Add(new Object[] { "1APL 090.150", "PANEL LOSA ALL STEEL 900X150", 900, 150, 0.135 });
            DtSalida.Rows.Add(new Object[] { "1APL 090.200", "PANEL LOSA ALL STEEL 900X200", 900, 200, 0.18 });
            DtSalida.Rows.Add(new Object[] { "1APL 090.250", "PANEL LOSA ALL STEEL 900X250", 900, 250, 0.225 });
            DtSalida.Rows.Add(new Object[] { "1APL 090.300", "PANEL LOSA ALL STEEL 900X300", 900, 300, 0.27 });
            DtSalida.Rows.Add(new Object[] { "1APL 090.450", "PANEL LOSA ALL STEEL 900X450", 900, 450, 0.405 });
            DtSalida.Rows.Add(new Object[] { "1APL 090.600", "PANEL LOSA ALL STEEL 900X600", 900, 600, 0.54 });
            DtSalida.Rows.Add(new Object[] { "1APL 120.100", "PANEL LOSA ALL STEEL 1200X100", 1200, 100, 0.12 });
            DtSalida.Rows.Add(new Object[] { "1APL 120.150", "PANEL LOSA ALL STEEL 1200X150", 1200, 150, 0.18 });
            DtSalida.Rows.Add(new Object[] { "1APL 120.200", "PANEL LOSA ALL STEEL 1200X200", 1200, 200, 0.24 });
            DtSalida.Rows.Add(new Object[] { "1APL 120.250", "PANEL LOSA ALL STEEL 1200X250", 1200, 250, 0.3 });
            DtSalida.Rows.Add(new Object[] { "1APL 120.300", "PANEL LOSA ALL STEEL 1200X300", 1200, 300, 0.36 });
            DtSalida.Rows.Add(new Object[] { "1APL 120.350", "PANEL LOSA ALL STEEL 1200X350", 1200, 350, 0.42 });
            DtSalida.Rows.Add(new Object[] { "1APL 120.400", "PANEL LOSA ALL STEEL 1200X400", 1200, 400, 0.48 });
            DtSalida.Rows.Add(new Object[] { "1APL 120.500", "PANEL LOSA ALL STEEL 1200X500", 1200, 500, 0.6 });
            DtSalida.Rows.Add(new Object[] { "1APM 060.100", "PANEL MURO ALL STEEL 600X100", 600, 100, 0.06 });
            DtSalida.Rows.Add(new Object[] { "1APM 060.140", "PANEL MURO ALL STEEL 600X140", 600, 140, 0.084 });
            DtSalida.Rows.Add(new Object[] { "1APM 060.150", "PANEL MURO ALL STEEL 600X150", 600, 150, 0.09 });
            DtSalida.Rows.Add(new Object[] { "1APM 060.200", "PANEL MURO ALL STEEL 600X200", 600, 200, 0.12 });
            DtSalida.Rows.Add(new Object[] { "1APM 060.250", "PANEL MURO ALL STEEL 600X250", 600, 250, 0.15 });
            DtSalida.Rows.Add(new Object[] { "1APM 060.300", "PANEL MURO ALL STEEL 600X300", 600, 300, 0.18 });
            DtSalida.Rows.Add(new Object[] { "1APM 060.350", "PANEL MURO ALL STEEL 600X350", 600, 350, 0.21 });
            DtSalida.Rows.Add(new Object[] { "1APM 060.400", "PANEL MURO ALL STEEL 600X400", 600, 400, 0.24 });
            DtSalida.Rows.Add(new Object[] { "1APM 060.450", "PANEL MURO ALL STEEL 600X450", 600, 450, 0.27 });
            DtSalida.Rows.Add(new Object[] { "1APM 060.500", "PANEL MURO ALL STEEL 600X500", 600, 500, 0.3 });
            DtSalida.Rows.Add(new Object[] { "1APM 060.550", "PANEL MURO ALL STEEL 600X550", 600, 550, 0.33 });
            DtSalida.Rows.Add(new Object[] { "1APM 060.600", "PANEL MURO ALL STEEL 600X600", 600, 600, 0.36 });
            DtSalida.Rows.Add(new Object[] { "1APM 080.150", "PANEL MURO ALL STEEL 800X150", 800, 150, 0.12 });
            DtSalida.Rows.Add(new Object[] { "1APM 080.200", "PANEL MURO ALL STEEL 800X200", 800, 200, 0.16 });
            DtSalida.Rows.Add(new Object[] { "1APM 080.250", "PANEL MURO ALL STEEL 800X250", 800, 250, 0.2 });
            DtSalida.Rows.Add(new Object[] { "1APM 080.300", "PANEL MURO ALL STEEL 800X300", 800, 300, 0.24 });
            DtSalida.Rows.Add(new Object[] { "1APM 080.350", "PANEL MURO ALL STEEL 800X350", 800, 350, 0.28 });
            DtSalida.Rows.Add(new Object[] { "1APM 080.400", "PANEL MURO ALL STEEL 800X400", 800, 400, 0.32 });
            DtSalida.Rows.Add(new Object[] { "1APM 080.450", "PANEL MURO ALL STEEL 800X450", 800, 450, 0.36 });
            DtSalida.Rows.Add(new Object[] { "1APM 080.500", "PANEL MURO ALL STEEL 800X500", 800, 500, 0.4 });
            DtSalida.Rows.Add(new Object[] { "1APM 080.550", "PANEL MURO ALL STEEL 800X550", 800, 550, 0.44 });
            DtSalida.Rows.Add(new Object[] { "1APM 080.600", "PANEL MURO ALL STEEL 800X600", 800, 600, 0.48 });
            DtSalida.Rows.Add(new Object[] { "1APM 090.100", "PANEL MURO ALL STEEL 900X100", 900, 100, 0.09 });
            DtSalida.Rows.Add(new Object[] { "1APM 090.150", "PANEL MURO ALL STEEL 900X150", 900, 150, 0.135 });
            DtSalida.Rows.Add(new Object[] { "1APM 090.200", "PANEL MURO ALL STEEL 900X200", 900, 200, 0.18 });
            DtSalida.Rows.Add(new Object[] { "1APM 090.250", "PANEL MURO ALL STEEL 900X250", 900, 250, 0.225 });
            DtSalida.Rows.Add(new Object[] { "1APM 090.300", "PANEL MURO ALL STEEL 900X300", 900, 300, 0.27 });
            DtSalida.Rows.Add(new Object[] { "1APM 090.350", "PANEL MURO ALL STEEL 900X350", 900, 350, 0.315 });
            DtSalida.Rows.Add(new Object[] { "1APM 090.400", "PANEL MURO ALL STEEL 900X400", 900, 400, 0.36 });
            DtSalida.Rows.Add(new Object[] { "1APM 090.450", "PANEL MURO ALL STEEL 900X450", 900, 450, 0.405 });
            DtSalida.Rows.Add(new Object[] { "1APM 090.500", "PANEL MURO ALL STEEL 900X500", 900, 500, 0.45 });
            DtSalida.Rows.Add(new Object[] { "1APM 090.550", "PANEL MURO ALL STEEL 900X550", 900, 550, 0.495 });
            DtSalida.Rows.Add(new Object[] { "1APM 090.600", "PANEL MURO ALL STEEL 900X600", 900, 600, 0.54 });
            DtSalida.Rows.Add(new Object[] { "1APM 120.100", "PANEL MURO ALL STEEL 1200X100", 1200, 100, 0.12 });
            DtSalida.Rows.Add(new Object[] { "1APM 120.125", "PANEL MURO ALL STEEL 1200X125", 1200, 125, 0.15 });
            DtSalida.Rows.Add(new Object[] { "1APM 120.150", "PANEL MURO ALL STEEL 1200X150", 1200, 150, 0.18 });
            DtSalida.Rows.Add(new Object[] { "1APM 120.200", "PANEL MURO ALL STEEL 1200X200", 1200, 200, 0.24 });
            DtSalida.Rows.Add(new Object[] { "1APM 120.250", "PANEL MURO ALL STEEL 1200X250", 1200, 250, 0.3 });
            DtSalida.Rows.Add(new Object[] { "1APM 120.300", "PANEL MURO ALL STEEL 1200X300", 1200, 300, 0.36 });
            DtSalida.Rows.Add(new Object[] { "1APM 120.350", "PANEL MURO ALL STEEL 1200X350", 1200, 350, 0.42 });
            DtSalida.Rows.Add(new Object[] { "1APM 120.400", "PANEL MURO ALL STEEL 1200X400", 1200, 400, 0.48 });
            DtSalida.Rows.Add(new Object[] { "1APM 120.450", "PANEL MURO ALL STEEL 1200X450", 1200, 450, 0.54 });
            DtSalida.Rows.Add(new Object[] { "1APM 120.500", "PANEL MURO ALL STEEL 1200X500", 1200, 500, 0.6 });
            DtSalida.Rows.Add(new Object[] { "1APM 120.550", "PANEL MURO ALL STEEL 1200X550", 1200, 550, 0.66 });
            DtSalida.Rows.Add(new Object[] { "1APM 120.600", "PANEL MURO ALL STEEL 1200X600", 1200, 600, 0.72 });
            DtSalida.Rows.Add(new Object[] { "1APM 210.600", "PANEL MURO ALL STEEL 2100X600", 2100, 600, 1.26 });
            DtSalida.Rows.Add(new Object[] { "1APM 240.100", "PANEL MURO ALL STEEL 2400X100", 2400, 100, 0.24 });
            DtSalida.Rows.Add(new Object[] { "1APM 240.125", "PANEL MURO ALL STEEL 2400X125", 2400, 125, 0.3 });
            DtSalida.Rows.Add(new Object[] { "1APM 240.150", "PANEL MURO ALL STEEL 2400X150", 2400, 150, 0.36 });
            DtSalida.Rows.Add(new Object[] { "1APM 240.200", "PANEL MURO ALL STEEL 2400X200", 2400, 200, 0.48 });
            DtSalida.Rows.Add(new Object[] { "1APM 240.250", "PANEL MURO ALL STEEL 2400X250", 2400, 250, 0.6 });
            DtSalida.Rows.Add(new Object[] { "1APM 240.300", "PANEL MURO ALL STEEL 2400X300", 2400, 300, 0.72 });
            DtSalida.Rows.Add(new Object[] { "1APM 240.350", "PANEL MURO ALL STEEL 2400X350", 2400, 350, 0.84 });
            DtSalida.Rows.Add(new Object[] { "1APM 240.400", "PANEL MURO ALL STEEL 2400X400", 2400, 400, 0.96 });
            DtSalida.Rows.Add(new Object[] { "1APM 240.450", "PANEL MURO ALL STEEL 2400X450", 2400, 450, 1.08 });
            DtSalida.Rows.Add(new Object[] { "1APM 240.500", "PANEL MURO ALL STEEL 2400X500", 2400, 500, 1.2 });
            DtSalida.Rows.Add(new Object[] { "1APM 240.550", "PANEL MURO ALL STEEL 2400X550", 2400, 550, 1.32 });
            DtSalida.Rows.Add(new Object[] { "1APM 240.600", "PANEL MURO ALL STEEL 2400X600", 2400, 600, 1.44 });
            DtSalida.Rows.Add(new Object[] { "1APM AJT.240", "PANEL DE AJUSTE T 2400X200", 2400, 200, 0.48 });
            DtSalida.Rows.Add(new Object[] { "1APM E00.028", "PANEL MURO ALL STEEL 800X140", 800, 140, 0.112 });
            DtSalida.Rows.Add(new Object[] { "1APM E00.047", "PANEL MURO ALL STEEL 2100X100", 2100, 100, 0.21 });
            DtSalida.Rows.Add(new Object[] { "1APM E00.048", "PANEL MURO ALL STEEL 2100X150", 2100, 150, 0.315 });
            DtSalida.Rows.Add(new Object[] { "1APM E00.049", "PANEL MURO ALL STEEL 2100X200", 2100, 200, 0.42 });
            DtSalida.Rows.Add(new Object[] { "1APM E00.050", "PANEL MURO ALL STEEL 2100X300", 2100, 300, 0.63 });
            DtSalida.Rows.Add(new Object[] { "1APM E00.053", "PANEL MURO ALL STEEL 2400X130", 2400, 130, 0.312 });
            DtSalida.Rows.Add(new Object[] { "1APM E00.057", "PANEL MURO ALL STEEL 2100X400", 2100, 400, 0.84 });
            DtSalida.Rows.Add(new Object[] { "1APM STB.009", "PANEL STB. 2400X135X50", 2400, 185, 0.444 });
            DtSalida.Rows.Add(new Object[] { "1APM STB.010", "PANEL STB. 2400X189X50", 2400, 239, 0.5736 });
            DtSalida.Rows.Add(new Object[] { "1APM STB.011", "PANEL STB. 2400X100X85", 2400, 185, 0.444 });
            DtSalida.Rows.Add(new Object[] { "1APM STB.012", "PANEL STB. 2400X140", 2400, 140, 0.336 });
            DtSalida.Rows.Add(new Object[] { "1APM STB.014", "PANEL STB. 2400X196X60", 2400, 256, 0.6144 });
            DtSalida.Rows.Add(new Object[] { "1APM STB.017", "PANEL STB. 2400X150X88", 2400, 238, 0.5712 });
            DtSalida.Rows.Add(new Object[] { "1APM STB.018", "PANEL STB. 2400X143X58", 2400, 201, 0.4824 });
            DtSalida.Rows.Add(new Object[] { "1APM STB.019", "PANEL STB. 2400X120", 2400, 120, 0.288 });
            DtSalida.Rows.Add(new Object[] { "1APM STB.020", "PANEL STB. 2400X223X83", 2400, 306, 0.7344 });
            DtSalida.Rows.Add(new Object[] { "1APM STB.021", "PANEL STB. 2400X117X52", 2400, 169, 0.4056 });
            DtSalida.Rows.Add(new Object[] { "1APM STB.023", "PANEL STB. 2400X149X50", 2400, 199, 0.4776 });
            DtSalida.Rows.Add(new Object[] { "1APM STB.025", "PANEL STB. 2400X178X58", 2400, 236, 0.5664 });
            DtSalida.Rows.Add(new Object[] { "1BCL CAM.001", "CANAL DOBLE DE AMARRE CONTRATERRENO", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1BCL CT1.500", "CANAL DOBLE CONTRATERRENO 1500", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1BCL CT2.500", "CANAL DOBLE CONTRATERRENO 2500", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1BCL CT3.000", "CANAL DOBLE CONTRATERRENO 3000", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1BCO EMC.001", "ESQUINERO MURO CONTRATERRENO", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1BCO EXT.020", "EXTRACTOR TORNILLO DE ANCLAJE M20", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1BCO FIJ.020", "FIJADOR TORNILLO DE ANCLAJE", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1BCO HC0.001", "HILO CONTINUO M20 X 600", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1BCO HC0.003", "HILO CONTINUO M20 X 400", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1BCO PAN.120", "TORNILLO DE ANCLAJE M20X120", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1BCO PAN.200", "TORNILLO DE ANCLAJE M20X200", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1BCO PAN.280", "TORNILLO DE ANCLAJE M24X280 (ROLL BACK)", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1BCO PAS.001", "PASADOR DIA. 24.5 X 100", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1BCO PER.007", "PERNO 5/8 X 4", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1BCO PER.008", "PERNO 5/8 X 3", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1BCO PL0.900", "PLANTILLA FIJ. TORNILLO DE ANCLAJE 900", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1BCO PL1.800", "PLANTILLA FIJ. TORNILLO DE ANCLAJE 1800", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1BCO PL2.700", "PLANTILLA FIJ. TORNILLO DE ANCLAJE 2700", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1BCO S00.500", "SOLDIER 7500", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1BCO S04.000", "SOLDIER 4000", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1BCO S06.000", "SOLDIER 6000", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1BCO SIZ.001", "SISTEMA DE IZAJE", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1BCO SO1.500", "SOLDIER 1500", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1BCO SO2.000", "SOLDIER 2000", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1BCO SO3.000", "SOLDIER 3000", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1BCO SO3.500", "SOLDIER 3500", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1BCO SO4.900", "SOLDIER 4900", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1BCO SO5.000", "SOLDIER 5000", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1BCO TCA.020", "TUERCA M20", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1FAC PAP.001", "PORTA APLOMADOR ALLSTEEL", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1FCO EIM.005", "MAGNUM ESQUINERO INT. (300X300) X 2400 (MADERA)", 2400, 600, 1.44 });
            DtSalida.Rows.Add(new Object[] { "1FM1 001.300", "VIGA DE MADERA (H150) 1300", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1FPL 240.400", "MAGNUM 240 PANEL 2400X400 (MADERA)", 2400, 400, 0.96 });
            DtSalida.Rows.Add(new Object[] { "1FPL 240.900", "MAGNUM 240 PANEL 2400X900 (MADERA)", 2400, 900, 2.16 });
            DtSalida.Rows.Add(new Object[] { "1FPL 240.901", "MAGNUM 240 PANEL REGULABLE 2400X900 (MADERA)", 2400, 900, 2.16 });
            DtSalida.Rows.Add(new Object[] { "1FPL 244.122", "PLACA FENOLICA UNISPAN 2.440 X 1.220", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1FVAIN EE01", "ESQUINERO EXTERIOR 300X50X50", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1FVAIN EI01", "ESQUINERO INTERIOR 300X150X150", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1FVAIN P001", "PANEL MURO ALL STEEL 850X600", 850, 600, 0.51 });
            DtSalida.Rows.Add(new Object[] { "1FVAIN P002", "PANEL MURO ALL STEEL 1300X600", 1300, 600, 0.78 });
            DtSalida.Rows.Add(new Object[] { "1FVAIN P003", "PANEL MURO ALL STEEL 2250X300", 2250, 300, 0.675 });
            DtSalida.Rows.Add(new Object[] { "1FVAIN P004", "PANEL MURO ALL STEEL 1350X300", 1350, 300, 0.405 });
            DtSalida.Rows.Add(new Object[] { "1FVAIN P005", "PANEL MURO ALL STEEL 1850X300", 1850, 300, 0.555 });
            DtSalida.Rows.Add(new Object[] { "1FVAIN P006", "PANEL MURO ALL STEEL 450X300", 450, 300, 0.135 });
            DtSalida.Rows.Add(new Object[] { "1FVAIN P007", "PANEL MURO ALL STEEL 1450X150", 1450, 150, 0.2175 });
            DtSalida.Rows.Add(new Object[] { "1FVAIN P008", "PANEL MURO ALL STEEL 2200X300", 2200, 300, 0.66 });
            DtSalida.Rows.Add(new Object[] { "1FVAIN P009", "PANEL MURO ALL STEEL 1600X300", 1600, 300, 0.48 });
            DtSalida.Rows.Add(new Object[] { "1HAC ALR.001", "CERROJO ESCUADRA CON ROSCA", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1HAC MEN.001", "MENSULA DE ACCESO MAGNUM", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1HAP APL.210", "MAGNUM APLOMADOR 2000-3400", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1HAP BRA.110", "MAGNUM APLOMADOR 1100-1500", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1HCO CDA.001", "MINIMAG CERROJO ALLSTEEL", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1HCO CER.001", "MINIMAG CERROJO", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1HCO CER.002", "MINIMAG CERROJO ALINEADOR", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1HCO CER.003", "MAGNUM CERROJO REGULABLE 180", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1HCO CER.004", "MINIMAG CERROJO ESQUINERO", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1HCO CER.005", "MINIMAG CERROJO ROBUST", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1HCO CER.006", "MINIMAG CERROJO ALINEADOR ROBUSTO", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1HCO CMA.001", "MAGNUM CERROJO", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1HCO CMA.002", "MAGNUM CERROJO REGULABLE 270", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1HCO CMA.003", "MAGNUM CERROJO ESCUADRA ESQ.EXTERNO", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1HCO CMA.004", "MAGNUM CERROJO ESQUINERO", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1HCO CMA.005", "MAGNUM CERROJO PRENSA ALLSTEEL", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1HCO EIM.001", "MAGNUM ESQUINERO INT. (300X300) X 3000", 3000, 600, 1.8 });
            DtSalida.Rows.Add(new Object[] { "1HCO EIM.002", "MAGNUM ESQUINERO INT. (300X300) X 1500", 1500, 600, 0.9 });
            DtSalida.Rows.Add(new Object[] { "1HCO EIM.003", "MAGNUM ESQ. INT.C/BISAGRA (300X300)X3000", 3000, 600, 1.8 });
            DtSalida.Rows.Add(new Object[] { "1HCO EIM.004", "MAGNUM ESQ. INT.C/BISAGRA (300X300)X1500", 1500, 600, 0.9 });
            DtSalida.Rows.Add(new Object[] { "1HCO EIM.005", "MAGNUM ESQUINERO INT. (300X300) X 2400", 2400, 600, 1.44 });
            DtSalida.Rows.Add(new Object[] { "1HCO EIM.006", "MAGNUM ESQUINERO INT. (300X300) X900", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1HCO EIM.007", "MAGNUM ESQ.INT. ALLSTEEL 300X300) X 900 NULO", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1HCO EIN.001", "MINIMAG ESQ. INTERNO (250X200)X 2400", 2400, 450, 1.08 });
            DtSalida.Rows.Add(new Object[] { "1HCO EIN.004", "MINIMAG ESQ.INTERNO CON BISAGRA 2400", 2400, 400, 0.96 });
            DtSalida.Rows.Add(new Object[] { "1HCO EIN.005", "MINIMAG ESQ.INTERNO (250X200)X 1200", 1200, 450, 0.54 });
            DtSalida.Rows.Add(new Object[] { "1HCO EXM.001", "MAGNUM ESQ. EXTERNO (0+0) X 3000", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1HCO EXM.002", "MAGNUM ESQ. EXTERNO (0+0) X 1500", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1HCO EXM.003", "MAGNUM ESQ. EXT.C/BISAGRA (300X300)X3000", 3000, 600, 1.8 });
            DtSalida.Rows.Add(new Object[] { "1HCO EXM.004", "MAGNUM ESQ. EXT.C/BISAGRA (300X300)X1500", 1500, 600, 0.9 });
            DtSalida.Rows.Add(new Object[] { "1HCO EXT.001", "MINIMAG ESQ. EXTERNO (0+0) X 2400", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1HCO EXT.003", "MINIMAG ESQ. EXTERNO (0+0) X 1200", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1HCO EXT.004", "MINIMAG ESQ.EXTERNO CON BISAGRA 2400", 2400, 500, 1.2 });
            DtSalida.Rows.Add(new Object[] { "1HCO GIZ.001", "MINIMAG GANCHO DE IZAJE", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1HCO GIZ.002", "MAGNUM GANCHO DE IZAJE", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1HCO GOL.D01", "GOLILLA 17", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1HCO GOL.M01", "GOLILLA 22 110 X 60 EXCENTRICA", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1HCO PSA.001", "PASADOR DE SEGURIDAD", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1HCO PSA.002", "PASADOR DIA.19X110", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1HCO STD.001", "SOPORTE TIRANTE 17", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1HCO STM.001", "SOPORTE TIRANTE 22", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1HCO TAD.001", "REGULADOR TAPA", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1HCO TAE.001", "FIJADOR 17 X 300 GANCHO", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1HCO TAE.002", "MAGNUM FIJADOR � 22", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1HCO TDU.001", "LLAVE TUERCA DUO", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1HCO TDU.002", "TUERCA 17", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1HCO TGO.001", "TUERCA CON GOLILLA 17", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1HCO TGO.002", "TUERCA CON GOLILLA 22", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1HCO TGO.004", "TUERCA CON GOLILLA D=22 MAGNUM ORIENTABLE", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1HCO TI0.040", "TIRANTE 17 X 400", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1HCO TI0.250", "FIJADOR 17 X 250", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1HCO TI0.400", "FIJADOR 17 X 400", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1HCO TI0.700", "TIRANTE 17 X 680 C/TOPE", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1HCO TI0.750", "TIRANTE 17 X 750", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1HCO TI1.000", "TIRANTE 17 X 1000", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1HCO TI1.500", "TIRANTE 17 X 1500", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1HCO TI2.000", "TIRANTE 17 X 2000", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1HCO TI2.500", "TIRANTE 17 X 2500", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1HCO TI3.000", "TIRANTE 17 X 3000", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1HCO TIM.001", "MAGNUM ALINEADOR", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1HCO TIM.003", "TIRANTE 22 X 1500", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1HCO TIM.004", "TIRANTE 22 X 2500", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1HCO TIM.005", "TIRANTE 22 X 1000", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1HCO TIM.022", "TIRANTE 22 X 3000", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1HCO TIM.200", "TIRANTE 22 X 2000", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1HCO TIM.400", "TIRANTE 22 X 400", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1HCO TIM.750", "TIRANTE 22 X 750", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1HCO TMA.001", "TUERCA 22", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1HFL 240.120", "MAGNUM 240 PANEL 2400X1200", 2400, 1200, 2.88 });
            DtSalida.Rows.Add(new Object[] { "1HFL 240.300", "MAGNUM 240 PANEL 2400X300", 2400, 300, 0.72 });
            DtSalida.Rows.Add(new Object[] { "1HFL 240.600", "MAGNUM 240 PANEL 2400X600", 2400, 600, 1.44 });
            DtSalida.Rows.Add(new Object[] { "1HFL 240.900", "MAGNUM 240 PANEL 2400X900", 2400, 900, 2.16 });
            DtSalida.Rows.Add(new Object[] { "1HFS 120.750", "MINIMAG PANEL 1200X750", 1200, 750, 0.9 });
            DtSalida.Rows.Add(new Object[] { "1HFS 240.600", "MINIMAG PANEL 2400X600", 2400, 600, 1.44 });
            DtSalida.Rows.Add(new Object[] { "1HFS 240.750", "MINIMAG PANEL 2400X750", 2400, 750, 1.8 });
            DtSalida.Rows.Add(new Object[] { "1HFX 150.300", "MAGNUM PANEL 1500X300", 1500, 300, 0.45 });
            DtSalida.Rows.Add(new Object[] { "1HFX 150.400", "MAGNUM PANEL 1500X400", 1500, 400, 0.6 });
            DtSalida.Rows.Add(new Object[] { "1HFX 150.500", "MAGNUM PANEL 1500X500", 1500, 500, 0.75 });
            DtSalida.Rows.Add(new Object[] { "1HFX 150.700", "MAGNUM PANEL 1500X700", 1500, 700, 1.05 });
            DtSalida.Rows.Add(new Object[] { "1HFX 150.800", "MAGNUM PANEL 1500X800", 1500, 800, 1.2 });
            DtSalida.Rows.Add(new Object[] { "1HFX 150.900", "MAGNUM PANEL 1500X900", 1500, 900, 1.35 });
            DtSalida.Rows.Add(new Object[] { "1HFX 300.100", "MAGNUM PANEL 3000X1000", 3000, 1000, 3 });
            DtSalida.Rows.Add(new Object[] { "1HFX 300.120", "MAGNUM PANEL 3000X1200", 3000, 1200, 3.6 });
            DtSalida.Rows.Add(new Object[] { "1HFX 300.180", "MAGNUM PANEL 3000X1800", 3000, 1800, 5.4 });
            DtSalida.Rows.Add(new Object[] { "1HFX 300.240", "MAGNUM PANEL 3000X2400", 3000, 2400, 7.2 });
            DtSalida.Rows.Add(new Object[] { "1HFX 300.300", "MAGNUM PANEL 3000X300", 3000, 300, 0.9 });
            DtSalida.Rows.Add(new Object[] { "1HFX 300.400", "MAGNUM PANEL 3000X400", 3000, 400, 1.2 });
            DtSalida.Rows.Add(new Object[] { "1HFX 300.500", "MAGNUM PANEL 3000X500", 3000, 500, 1.5 });
            DtSalida.Rows.Add(new Object[] { "1HFX 300.600", "MAGNUM PANEL 3000X600", 3000, 600, 1.8 });
            DtSalida.Rows.Add(new Object[] { "1HFX 300.700", "MAGNUM PANEL 3000X700", 3000, 700, 2.1 });
            DtSalida.Rows.Add(new Object[] { "1HFX 300.800", "MAGNUM PANEL 3000X800", 3000, 800, 2.4 });
            DtSalida.Rows.Add(new Object[] { "1HFX 300.900", "MAGNUM PANEL 3000X900", 3000, 900, 2.7 });
            DtSalida.Rows.Add(new Object[] { "1HFX RE3.000", "MAGNUM PANEL REGULABLE 3000X1000", 3000, 1000, 3 });
            DtSalida.Rows.Add(new Object[] { "1HLAC MEN.001", "MENSULA DE ACCESO DUO LIGHT", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1HLAP APL.001", "APLOMADOR DUO LIGHT", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1HLCO CER.001", "CERROJO REGULABLE DUO LIGHT", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1HLCO EXT.001", "ESQUINERO DUO LIGHT EXTERNO 2400", 2400, 600, 1.44 });
            DtSalida.Rows.Add(new Object[] { "1HLCO GIZ.001", "GANCHO DE IZAJE DUO LIGHT", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1HLCO INT.001", "ESQUINERO DUO LIGHT INTERNO 2400", 2400, 0.2, 0.00048 });
            DtSalida.Rows.Add(new Object[] { "1HLCO TGO.001", "TUERCA CON GOLILLA DUO LIGHT", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1HLPM 240.050", "DUO LIGHT PANEL DE AJUSTE 2400X50", 2400, 50, 0.12 });
            DtSalida.Rows.Add(new Object[] { "1HLPM 240.200", "PANEL DUO LIGHT 2400X200", 2400, 200, 0.48 });
            DtSalida.Rows.Add(new Object[] { "1HLPM 240.300", "PANEL DUO LIGHT 2400X300", 2400, 300, 0.72 });
            DtSalida.Rows.Add(new Object[] { "1HLPM 240.400", "PANEL DUO LIGHT 2400X400", 2400, 400, 0.96 });
            DtSalida.Rows.Add(new Object[] { "1HLPM 240.500", "PANEL DUO LIGHT 2400X500", 2400, 500, 1.2 });
            DtSalida.Rows.Add(new Object[] { "1HLPM 240.600", "PANEL DUO LIGHT 2400X600", 2400, 600, 1.44 });
            DtSalida.Rows.Add(new Object[] { "1HLPM 240.750", "PANEL DUO LIGHT 2400X750", 2400, 750, 1.8 });
            DtSalida.Rows.Add(new Object[] { "1HMA 060.300", "MAGNUM ALLSTEEL PANEL 600X300", 600, 300, 0.18 });
            DtSalida.Rows.Add(new Object[] { "1HMA 090.300", "MAGNUM ALLSTEEL PANEL 900X300", 900, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1HMA EI0.600", "MAGNUM ALLSTEEL ESQUINERO 600X300X300", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1HMA EI0.900", "MAGNUM ALLSTEEL ESQUINERO 900X300X300", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1HPA 240.100", "MAGNUM 240 ALLSTEEL PANEL 2400X100", 2400, 100, 0.24 });
            DtSalida.Rows.Add(new Object[] { "1HPA 240.150", "MAGNUM 240 ALLSTEEL PANEL 2400X150", 2400, 150, 0.36 });
            DtSalida.Rows.Add(new Object[] { "1HPA 240.200", "MAGNUM 240 ALLSTEEL PANEL 2400X200", 2400, 200, 0.48 });
            DtSalida.Rows.Add(new Object[] { "1HPA 240.250", "MAGNUM 240 ALLSTEEL PANEL 2400X250", 2400, 250, 0.6 });
            DtSalida.Rows.Add(new Object[] { "1HPA 240.300", "MAGNUM 240 ALLSTEEL PANEL 2400X300", 2400, 300, 0.72 });
            DtSalida.Rows.Add(new Object[] { "1HPA AJU.150", "MINIMAG PANEL AJUSTE 2400X150", 2400, 150, 0.36 });
            DtSalida.Rows.Add(new Object[] { "1HPL 240.200", "MAGNUM 240 PANEL 2400X200 F", 2400, 200, 0.48 });
            DtSalida.Rows.Add(new Object[] { "1HPL 240.300", "MAGNUM 240 PANEL 2400X300 F", 2400, 300, 0.72 });
            DtSalida.Rows.Add(new Object[] { "1HPL 240.400", "MAGNUM 240 PANEL 2400X400 F", 2400, 400, 0.96 });
            DtSalida.Rows.Add(new Object[] { "1HPL 240.500", "MAGNUM 240 PANEL 2400X500 F", 2400, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1HPL 240.600", "MAGNUM 240 PANEL 2400X600 F", 2400, 600, 1.44 });
            DtSalida.Rows.Add(new Object[] { "1HPL 240.700", "MAGNUM 240 PANEL 2400X700 F", 2400, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1HPL 240.900", "MAGNUM 240 PANEL 2400X900 F", 2400, 900, 2.16 });
            DtSalida.Rows.Add(new Object[] { "1HPL 240.901", "MAGNUM 240 PANEL REGULABLE 2400X900 F", 2400, 900, 2.16 });
            DtSalida.Rows.Add(new Object[] { "1HPM 001.200", "MAGNUM PANEL 3000X1200 F", 3000, 1200, 3.6 });
            DtSalida.Rows.Add(new Object[] { "1HPM 002.400", "MAGNUM PANEL 3000X2400 F", 3000, 2400, 7.2 });
            DtSalida.Rows.Add(new Object[] { "1HPM 090.300", "MAGNUM PANEL 900X300 F", 900, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1HPM 090.600", "MAGNUM PANEL 900X600 F", 900, 600, 0.54 });
            DtSalida.Rows.Add(new Object[] { "1HPM 120.200", "MINIMAG PANEL 1200X200", 1200, 200, 0.24 });
            DtSalida.Rows.Add(new Object[] { "1HPM 120.300", "MINIMAG PANEL 1200X300", 1200, 300, 0.36 });
            DtSalida.Rows.Add(new Object[] { "1HPM 120.400", "MINIMAG PANEL 1200X400", 1200, 400, 0.48 });
            DtSalida.Rows.Add(new Object[] { "1HPM 120.500", "MINIMAG PANEL 1200X500", 1200, 500, 0.6 });
            DtSalida.Rows.Add(new Object[] { "1HPM 120.600", "MINIMAG PANEL 1200X600", 1200, 600, 0.72 });
            DtSalida.Rows.Add(new Object[] { "1HPM 120.750", "MINIMAG PANEL 1200X750 F", 1200, 750, 0.9 });
            DtSalida.Rows.Add(new Object[] { "1HPM 150.100", "MAGNUM PANEL REGULABLE 1500X1000 F", 1500, 1000, 1.5 });
            DtSalida.Rows.Add(new Object[] { "1HPM 150.120", "MAGNUM PANEL 1500X1200 F", 1500, 1200, 1.8 });
            DtSalida.Rows.Add(new Object[] { "1HPM 150.300", "MAGNUM PANEL 1500X300 F", 1500, 300, 0.45 });
            DtSalida.Rows.Add(new Object[] { "1HPM 150.400", "MAGNUM PANEL 1500X400 F", 1500, 400, 0.6 });
            DtSalida.Rows.Add(new Object[] { "1HPM 150.500", "MAGNUM PANEL 1500X500 F", 1500, 500, 0.75 });
            DtSalida.Rows.Add(new Object[] { "1HPM 150.600", "MAGNUM PANEL 1500X600 F", 1500, 600, 0.9 });
            DtSalida.Rows.Add(new Object[] { "1HPM 150.700", "MAGNUM PANEL 1500X700 F", 1500, 700, 1.05 });
            DtSalida.Rows.Add(new Object[] { "1HPM 150.800", "MAGNUM PANEL 1500X800 F", 1500, 800, 1.2 });
            DtSalida.Rows.Add(new Object[] { "1HPM 150.900", "MAGNUM PANEL 1500X900 F", 1500, 900, 1.35 });
            DtSalida.Rows.Add(new Object[] { "1HPM 240.120", "MAGNUM 240 PANEL 2400X1200 F", 2400, 1200, 2.88 });
            DtSalida.Rows.Add(new Object[] { "1HPM 240.200", "MINIMAG PANEL 2400X200", 2400, 200, 0.48 });
            DtSalida.Rows.Add(new Object[] { "1HPM 240.300", "MINIMAG PANEL 2400X300", 2400, 300, 0.72 });
            DtSalida.Rows.Add(new Object[] { "1HPM 240.400", "MINIMAG PANEL 2400X400", 2400, 400, 0.96 });
            DtSalida.Rows.Add(new Object[] { "1HPM 240.500", "MINIMAG PANEL 2400X500", 2400, 500, 1.2 });
            DtSalida.Rows.Add(new Object[] { "1HPM 240.600", "MINIMAG PANEL 2400X600 F", 2400, 600, 1.44 });
            DtSalida.Rows.Add(new Object[] { "1HPM 240.750", "MINIMAG PANEL 2400X750 F", 2400, 750, 1.8 });
            DtSalida.Rows.Add(new Object[] { "1HPM 300.010", "MAGNUM PANEL 3000X1000 F", 3000, 1000, 3 });
            DtSalida.Rows.Add(new Object[] { "1HPM 300.100", "MAGNUM PANEL REGULABLE 3000X1000 F", 3000, 1000, 3 });
            DtSalida.Rows.Add(new Object[] { "1HPM 300.300", "MAGNUM PANEL 3000X300 F", 3000, 300, 0.9 });
            DtSalida.Rows.Add(new Object[] { "1HPM 300.400", "MAGNUM PANEL 3000X400 F", 3000, 400, 1.2 });
            DtSalida.Rows.Add(new Object[] { "1HPM 300.500", "MAGNUM PANEL 3000X500 F", 3000, 500, 1.5 });
            DtSalida.Rows.Add(new Object[] { "1HPM 300.600", "MAGNUM PANEL 3000X600 F", 3000, 600, 1.8 });
            DtSalida.Rows.Add(new Object[] { "1HPM 300.700", "MAGNUM PANEL 3000X700 F", 3000, 700, 2.1 });
            DtSalida.Rows.Add(new Object[] { "1HPM 300.800", "MAGNUM PANEL 3000X800 F", 3000, 800, 2.4 });
            DtSalida.Rows.Add(new Object[] { "1HPM 300.900", "MAGNUM PANEL 3000X900 F", 3000, 900, 2.7 });
            DtSalida.Rows.Add(new Object[] { "1HPM 300X180", "MAGNUM PANEL 3000X1800 F", 3000, 1800, 5.4 });
            DtSalida.Rows.Add(new Object[] { "1HPM AJ1.050", "MINIMAG PANEL DE AJUSTE 1200X50", 1200, 50, 0.06 });
            DtSalida.Rows.Add(new Object[] { "1HPM AJ3.050", "MAGNUM PANEL DE AJUSTE 3000X50", 3000, 50, 0.15 });
            DtSalida.Rows.Add(new Object[] { "1HPM AJ3.100", "MAGNUM PANEL DE AJUSTE 3000X100", 3000, 100, 0.3 });
            DtSalida.Rows.Add(new Object[] { "1HPM AJ3.400", "MAGNUM PANEL DE AJUSTE 3000X400", 3000, 400, 1.2 });
            DtSalida.Rows.Add(new Object[] { "1HPM AJU.050", "MAGNUM PANEL DE AJUSTE 2400X50", 2400, 50, 0.12 });
            DtSalida.Rows.Add(new Object[] { "1HPM AJU.100", "MAGNUM PANEL DE AJUSTE 2400X100", 2400, 100, 0.24 });
            DtSalida.Rows.Add(new Object[] { "1HPM.PLPL1479", "PLACA PLASTICA 1479X279X18MM P/MAG.PANEL1500X300", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1HPM.PLPLA017", "PLACA PLASTICA 1479X1179X18MM P/MAG.PANEL1500X1200", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1LCO GRA.001", "PIN GRAPA ALU (IZQUIERDO)", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1LCO GRA.002", "PIN GRAPA ALU (DERECHO)", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1LCO PAS.001", "PASADOR ALU � 16 X 65 STANDARD", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1LCO PAS.002", "PASADOR ALU � 16 X 75 MEDIANO", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1LCO PAS.005", "PASADOR ALU � 16 X 115 LARGO", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1MG0110002400", "TUBO ALU PARA TENSION LONA CON TAPONES 240", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1MG0230002500", "LARGUERO DE CABEZA TENSIONADOR DE 250 ALU", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1MG0240000830", "LARGUERO FIJACION LONAS DE 0.83", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1MG0240002500", "LARGUERO FIJACION LONAS DE 2.50", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1MG0810375001", "GUIA LONA ALU 60X37 DE 500 CON ESPIGA", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1MG0821061480", "CERROJO TENAZA PARA GUIA LONA", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1MG0921250830", "ESPIGA DIAM. 12.5", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1MG0930384004", "ESPIGA DE 400 GRIS 4 AGUJEROS", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1MG0992002000", "TENSIONADOR PARA TENSION LONA DE 200", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1MG1111153300", "VIGA CUMBRE COBERTURA BUILING 335X115 ALU", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1MG1120741001", "VIGA TERMINAL COBERTURA BUILDING 100X74", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1MG1130743000", "VIGA COBERTURA BUILDING 300X74 ALU", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1MG1230002500", "LARGUERO COBERTURA BUILDING DE 250 ALU", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1MG1230502500", "LARGUERO DOBLE COBERTURA BUILDING 250X50 ALU", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1MG1240002500", "LARGUERO CENTRAL COBERTURA BUILDING 250 ALU", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1MG1262002500", "DIAGONAL COBERTURA BUILDING 250X200 ALU", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1MG1420701150", "SOPORTE OSCILANTE COBERTURA BUILDING 70X115", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1MG4112501080", "LONA PVC COBERTURA BUILDING 2.50X12.65", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1MG4142501080", "LONA PVC CUMBRE VIGA DE 10.80 (2 PIEZAS)", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1MG4170835000", "LONA PVC PROTECCION VERTICAL DE 0.83 H=5.00", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1MG4172505000", "LONA PVC PROTECCION VERTICAL DE 2.5 H=5.00", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1MTD 403.061", "GATA BASE REGULABLE INCLINADO DE 60", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1MTD 415.511a", "ESCALERA INTERMEDIA 250X72X200", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1MTD 415.515", "PASAMANO ESCALERA AMD", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1MTD 415.517", "PASAMANO EXTREMO ESCALERA", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1MTD 420.083", "PLATAFORMA 83X33", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1MTD 420.100", "PLATAFORMA 100X33", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1MTD 420.115", "PLATAFORMA 115X33", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1MTD 420.150", "PLATAFORMA 150X33", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1MTD 420.200", "PLATAFORMA 200X33", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1MTD 420.250", "PLATAFORMA 250X33", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1MTD 420.300", "PLATAFORMA 300X33", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1MTD 424.115", "PLATAF. ESCOTILLA 115", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1MTD 424.115e", "ESCALERA ESCOTILLA 115", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1MTD 424.250", "PLATAF.ESCOT.+ESCALERA 250", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1MTD 424.300", "PLATAF.ESCOT.+ESCALERA 300", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1MTD 428.083", "RODAPIE AMD 83", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1MTD 428.100", "RODAPIE AMD 100", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1MTD 428.115", "RODAPIE AMD 115", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1MTD 428.150", "RODAPIE AMD 150", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1MTD 428.200", "RODAPIE AMD 200", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1MTD 428.250", "RODAPIE AMD 250", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1MTD 428.300", "RODAPIE AMD 300", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1MTD 471.025", "PIE VERTICAL AMD 25 CON ESPIGA", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1MTD 471.030", "PIEZA DE INICIO AMD 30", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1MTD 471.040", "PIEZA DE INICIO INTERMEDIO AMD", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1MTD 471.050", "PIE VERTICAL AMD 50 CON ESPIGA", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1MTD 471.100", "PIE VERTICAL AMD 100 CON ESPIGA", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1MTD 471.101", "PIE VERTICAL AMD 100 SIN ESPIGA", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1MTD 471.150", "PIE VERTICAL AMD 150 CON ESPIGA", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1MTD 471.151", "PIE VERTICAL AMD 150 SIN ESPIGA", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1MTD 471.200", "PIE VERTICAL AMD 200 CON ESPIGA", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1MTD 471.201", "PIE VERTICAL AMD 200 SIN ESPIGA", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1MTD 471.300", "PIE VERTICAL AMD 300 CON ESPIGA", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1MTD 471.400", "PIE VERTICAL AMD 400 CON ESPIGA", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1MTD 472.083", "LARGUERO AMD 83", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1MTD 472.100", "LARGUERO AMD 100", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1MTD 472.115", "LARGUERO AMD 115", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1MTD 472.150", "LARGUERO AMD 150", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1MTD 472.200", "LARGUERO AMD 200", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1MTD 472.250", "LARGUERO AMD 250", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1MTD 472.300", "LARGUERO AMD 300", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1MTD 473.083", "DIAGONAL AMD C/GIRATORIA 83X200 (212)", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1MTD 473.100", "DIAGONAL AMD C/GIRATORIA 200X100 (209)", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1MTD 473.105", "DIAGONAL AMD C/GIRATORIA 100X200 (217)", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1MTD 473.115", "DIAGONAL AMD C/GIRATORIA 115X200 (223)", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1MTD 473.150", "DIAGONAL AMD C/GIRATORIA 150X200 (241)", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1MTD 473.200", "DIAGONAL AMD C/GIRATORIA 200X200 (272)", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1MTD 473.210", "DIAGONAL AMD C/GIRATORIA 250X100", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1MTD 473.250", "DIAGONAL AMD C/GIRATORIA 250X200 (308)", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1MTD 473.300", "DIAGONAL AMD C/GIRATORIA 300X200 (347)", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1MTD 474.230", "DIAGONAL PLANTA AMD C/FIJA 250X200 (316)", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1MTD 474.245", "DIAGONAL PLANTA AMD C/FIJA 250X150 (288)", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1MTD 474.250", "DIAGONAL PLANTA AMD C/FIJA 250X115", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1MTD 474.255", "DIAGONAL PLANTA AMD C/FIJA 250X83 (260)", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1MTD 475.010", "MENSULA DE TRABAJO AMD 33", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1MTD 475.017", "MENSULA DE TRABAJO AMD 83", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1MTD 475.500", "VIGA PUENTE 500", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1MTD 476 115", "TRANSVERSAL AMD 115", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1MTD 476.150", "TRAVESA�O REFORZADO AMD 150", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1MTD 476.200", "TRAVESA�O REFORZADO AMD 200", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1MTD 476.250", "TRAVESA�O REFORZADO AMD 250", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1MTD 476.300", "TRAVESA�O REFORZADO AMD 300", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1MTD 477.200", "VIGA CELOSIA AMD 200", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1MTD 477.250", "VIGA CELOSIA AMD 250", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1MTD 477.500", "VIGA CELOSIA AMD 500", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1MTD 477.600", "VIGA CELOSIA AMD 600", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1MTD 478.005", "CONECTOR ESPIGA AMD", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1MTD 478.010", "BUJE PARA CABEZAL AMD", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1MTD 478.015", "ROSETA MOVIL AMD", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1MTD 478.022", "CABEZAL DOBLE", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1MTD 479.083", "PLATAFORMA DE CIERRE 83", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1MTD 479.100", "PLATAFORMA DE CIERRE 100", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1MTD 479.150", "PLATAFORMA DE CIERRE 150", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1MTD 479.200", "PLATAFORMA DE CIERRE 200", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1MTD 479.250", "PLATAFORMA DE CIERRE 250", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1MTD 479.300", "PLATAFORMA DE CIERRE 300", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1MTD 479.800", "SOPORTE INFERIOR TORRE CARGA", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1MTD 479.810", "SOPORTE SUPERIOR TORRE CARGA", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1MTD 479.820", "GATA BASE HD TORRE CARGA", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1MTD 479.830", "CABEZAL HD TORRE CARGA", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1MTD 479.LLA", "LLAVE PUNTA 100 MM", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1MTD 712.520", "ESCALERA 250X200 LATERAL RAMPA", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1MTD 730.083", "ESCALERA 250X200 CIERRE SUPERIOR 83", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1MTD 730.115", "ESCALERA 250X200 CIERRE SUPERIOR 115", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1MTD 730.150", "ESCALERA 250X200 CIERRE SUPERIOR 150", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1MTD 730.180", "ESCALERA 250X200 CIERRE SUPERIOR 180", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1MTD 730.200", "ESCALERA 250X200 CIERRE SUPERIOR 200", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1MTD 730.250", "ESCALERA 250X200 CIERRE SUPERIOR 250", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1MTD 731.083", "ESCALERA 250X200 CIERRE INFERIOR 83", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1MTD 731.115", "ESCALERA 250X200 CIERRE INFERIOR 115", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1MTD 731.200", "ESCALERA 250X200 CIERRE INFERIOR 200", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1MTD 731.250", "ESCALERA 250X200 CIERRE INFERIOR 250", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1MTD 742.510", "ESCALERA 250X200 RODAPIE DERECHO (d)", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1MTD 742.515", "ESCALERA 250X200 RODAPIE IZQUIERDO (i)", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1MTD 742.520", "ESCALERA 250X200 ELEMENTO SUPERIOR RODAPIE", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1MTD 742.520d", "ESCALERA 250X200 ELEMENTO SUPERIOR RODAPIE DERECHO", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1MTD 742.520i", "ESCALERA 250X200 ELEMENTO SUPERIOR RODAPIE IZQUIER", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1MTD MEN.115", "MENSULA DE TRABAJO AMD 115", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1OPC 240.030", "PANEL CIRCULAR H=2400 D=300", 2400, 0.94, 0.002256 });
            DtSalida.Rows.Add(new Object[] { "1OPC 240.050", "PANEL CIRCULAR H=2400 D=500", 2400, 1.57, 0.003768 });
            DtSalida.Rows.Add(new Object[] { "1OPC 240.060", "PANEL CIRCULAR H=2400 D=600", 2400, 1.88, 0.004512 });
            DtSalida.Rows.Add(new Object[] { "1OPC 300.025", "PANEL CIRCULAR H=3000 D=250", 3000, 0.78, 0.00234 });
            DtSalida.Rows.Add(new Object[] { "1OPC 300.030", "PANEL CIRCULAR H=3000 D=300", 3000, 0.94, 0.00282 });
            DtSalida.Rows.Add(new Object[] { "1OPC 300.040", "PANEL CIRCULAR H=3000 D=400", 3000, 1.26, 0.00378 });
            DtSalida.Rows.Add(new Object[] { "1OPC 300.050", "PANEL CIRCULAR H=3000 D=500", 3000, 1.57, 0.00471 });
            DtSalida.Rows.Add(new Object[] { "1OPC 300.060", "PANEL CIRCULAR H=3000 D=600", 3000, 1.88, 0.00564 });
            DtSalida.Rows.Add(new Object[] { "1OPC 300.070", "PANEL CIRCULAR H=3000 D=700", 3000, 2.2, 0.0066 });
            DtSalida.Rows.Add(new Object[] { "1OPC 300.080", "PANEL CIRCULAR H=3000 D=800", 3000, 2.51, 0.00753 });
            DtSalida.Rows.Add(new Object[] { "1RAC GRA.022", "COPLA VIGA DE CELOSIA AM72L 22", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1RAC HOU.073", "HORIZONTAL U AM72L PARA VIGA CELOSIA 0.73m", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1RAC MEN.073", "MENSULA DE ANDAMIO AM72L 73", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1RAC VGC.514", "VIGA CELOSIA AM72L 5.14M", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1RCO BLD.073", "BARANDILLA LATERAL DOBLE AM72L 73", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1RCO DIA.257", "DIAGONAL AM72L 257", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1RCO DIA.307", "DIAGONAL AM72L 307", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1RCO LGR.257", "LARGUERO AM72L 257", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1RCO LGR.307", "LARGUERO AM72L 307", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1RCO MCI.073", "MARCO DE CORONACION INTERMEDIO AM72L 73", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1RCO MCL.073", "MARCO DE CORONACION LATERAL AM72L 73", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1RCO PBA.000", "POSTE PARA BARANDILLA AM72L", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1RCO PES.257", "PLATAFORMA ESCALERA AM72L 257", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1RCO PES.307", "PLATAFORMA ESCALERA AM72L 307", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1RCO PLA.257", "PLATAFORMA AM72L 257 X 32", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1RCO PLA.307", "PLATAFORMA AM72L 307 X 32", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1RCO POR.001", "MARCO EURO AM72L 200 X 73", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1RCO ROD.073", "RODAPIE LATERAL AM72L 73", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1RCO ROD.257", "RODAPIE AM72L 257", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1RCO ROD.307", "RODAPIE AM72L 307", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1RCO TRU.073", "TRAVESA�O U AM72L 73 CON GRAPA", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1SAC EGA.001", "ESCALERA GATO 3000", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1SAC EGA.002", "ESCALERA GATO 2000", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1SAC EME.001", "ESCALERA METALICA", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1SAC EME.E02", "ESCALERA METALICA 250x200x56", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1SAC RUE.003", "RUEDA GATA 1000 KGS. X 200", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1SAC TM2.500", "TABLON METALICO 2500", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1SAM 000.915", "MARCO 915 X 1220 HI LOAD", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1SAM 001.830", "MARCO 1830 X 1220 HI LOAD", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1SAM CON.001", "CONECTOR HI LOAD", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1SAM DI1.760", "CRUCETA HI LOAD 1760", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1SAM DI2.500", "CRUCETA HI LOAD 2500", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1SAM GAU.001", "CABEZA U HI LOAD", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1SAM GHI.001", "HILO GATA HI LOAD", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1SAM GMU.001", "CABEZA MULTIVIA HI LOAD", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1SAM GTU.001", "TUERCA PARA HILO HI LOAD", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1SAM PBA.001", "PLACA BASE HI LOAD", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1SAM PSA.001", "PASADOR DIA. 16 X 75 HI LOAD", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1SCM CME.001", "CABEZA MULTIVIA CON ESPIGA", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1SCO BAR.001", "BARANDA DE BORDE", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1SCO COR.001", "CORREDERA", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1SCO PSA.001", "PLACA PASAMANO 250X30X10", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1SCO PSA.002", "PLACA PASAMANO 200X30X10", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1SCO PSA.ESC", "PASAMANO ESCALA", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1SCO PSE.E04", "PASAMANO EXTREMO", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1SCO PSI.E03", "PASAMANO INTERMEDIO", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1SCO PTP.001", "PORTA TUBO PASAMANOS", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1SGT GAJ.001", "GATA CABEZA J", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1SGT GAU.001", "GATA CABEZA U", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1SGT GBA.001", "GATA BASE", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1SGT GBA.004", "GATA BASE 1500MM", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1SGT GDO.001", "GATA DOBLE CABEZA", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1SGT GMU.001", "GATA MULTIVIAS", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1SGT GMU.002", "SOPORTE GATA - MURO", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1SGT PBA.001", "PLACA BASE", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1SGT PGA.001", "CLIP PORTA GATA BASE SOLIDA", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1SPU 001.000", "PUNTAL 1000", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1SPU 001.500", "PUNTAL 1500", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1SPU 002.000", "PUNTAL 2000", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1SPU 002.500", "PUNTAL 2500", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1SPU 003.000", "PUNTAL 3000", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1SPU 004.000", "PUNTAL 4000", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1SPU TR1.800", "PUNTAL TRIPODE 1800", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1SPU TR2.200", "PUNTAL TRIPODE 2200", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1STR P02.500", "TRAVESA�O 2500MM C/P 100X50X3", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1STR PT1.500", "TRAVESAÑO CERCHA PT 1500", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1STR PT2.000", "TRAVESAÑO CERCHA PT 2000", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1STR REF.150", "TRAVESA�O REFORZADO PT 1500", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1STR REF.250", "TRAVESA�O REFORZADO PT 2500", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1STR TR0.600", "TRAVESA�O 600", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1STR TR0.800", "TRAVESA�O 800", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1STR TR0.900", "TRAVESA�O 900", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1STR TR1.000", "TRAVESA�O 1000", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1STR TR1.300", "TRAVESA�O 1300", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1STR TR1.500", "TRAVESA�O 1500", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1STR TR2.000", "TRAVESA�O 2000", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1STR TR2.500", "TRAVESA�O 2500", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1STR TRI.001", "TRIPODE", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1UAC DIA.072", "SOPORTE PARA MENSULA P-72", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1UAC MAR.150", "MARQUESINA P-72", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1UAC MEN.072", "MENSULA MARCO AM72 - 66", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1UAC PAL.001", "PALET MARCO AM72 34", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1UCO ABR.001", "COPLA FIJA 90�", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1UCO ANC.002", "ANCLAJE ROSCA INTERNA 3/4", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1UCO ANC.040", "TUBO ANCLAJE 400", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1UCO ANC.250", "TUBO ANCLAJE 2000", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1UCO ANC.FIJ", "CAJA ANCLAJE FIJO", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1UCO ANC.PIV", "TUBO ANCLAJE DIAGONAL CON PIVOTE", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1UCO BEG.001", "BARANDA TERMINAL", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1UCO BEG.002", "CORONACION MARCO AM72", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1UCO CER.001", "CERCHA TRIPLE AM72P 500X70", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1UCO DI1.500", "DIAGONAL AM72P 165", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1UCO DI2.500", "DIAGONAL AM72P 265", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1UCO DI3.000", "DIAGONAL AM72P 315", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1UCO GBA.001", "GATA BASE AM", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1UCO LG1.500", "LARGUERO AM72P 150", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1UCO LG2.500", "LARGUERO AM72P 250", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1UCO LG3.000", "LARGUERO AM72P 300", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1UCO MEN.033", "MENSULA MARCO AM72 - 33", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1UCO PES.250", "PLATAF.ESCOT.+ESCALERA AM72P 250", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1UCO PLA.250", "PLATAFORMA ANDAMIO AM72P 250X33", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1UCO POR.001", "MARCO AM72 200X72", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1UCO PSA.001", "PASADOR DE SEGURIDAD AM72/AMD", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1UCO R01.500", "RODAPIE AM72P 150", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1UCO RO2.500", "RODAPIE AM72P 250", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1UCO RO3.000", "RODAPIE AM72P 300", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1VA1 001.000", "VIGA DE ALUMINIO (H=150) 1000", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1VA1 001.300", "VIGA DE ALUMINIO (H=150) 1300", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1VA1 001.800", "VIGA DE ALUMINIO (H=150) 1800", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1VA1 002.000", "VIGA DE ALUMINIO (H=150) 2000", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1VA1 002.100", "VIGA DE ALUMINIO (H=150) 2100", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1VA1 002.500", "VIGA DE ALUMINIO (H=150) 2500", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1VA1 002.700", "VIGA DE ALUMINIO (H=150) 2700", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1VA1 003.300", "VIGA DE ALUMINIO (H=150) 3300", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1VA1 003.800", "VIGA DE ALUMINIO (H=150) 3800", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1VA1 005.300", "VIGA DE ALUMINIO (H=150) 5300", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1VA1 011.400", "VIGA DE ALUMINIO (H=150) 11400", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1VA3 004.880", "VIGA DE ALUMINIO (H=165) 4880 HI LOAD", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1VM1 002.100", "VIGA DE MADERA (H150) 2100", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1VM1 002.700", "VIGA DE MADERA (H150) 2700", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1VM1 003.300", "VIGA DE MADERA (H150) 3300", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1VM1 003.800", "VIGA DE MADERA (H150) 3800", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1VMT 001.000", "VIGA PLACA 1000", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1VMT 001.300", "VIGA PLACA 1300", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1VMT 001.500", "VIGA PLACA 1500", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1VMT 002.000", "VIGA PLACA 2000", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1VMT 002.100", "VIGA PLACA 2100", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1VMT 002.700", "VIGA PLACA 2700", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1VUN 001.000", "VIGA UNI 1000", 1000, 100, 0.1 });
            DtSalida.Rows.Add(new Object[] { "1VUN 001.500", "VIGA UNI 1500", 1500, 100, 0.15 });
            DtSalida.Rows.Add(new Object[] { "1VUN 002.000", "VIGA UNI 2000", 2000, 100, 0.2 });
            DtSalida.Rows.Add(new Object[] { "1VUN 002.500", "VIGA UNI 2500", 2500, 100, 0.25 });
            DtSalida.Rows.Add(new Object[] { "1VUN 009.000", "VIGA UNI 900", 900, 100, 0.09 });
            DtSalida.Rows.Add(new Object[] { "1VUN E01.500", "VIGA UNI EXTENSION 1500", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1WAC RAS.001", "RASPADOR DUO 1500X75", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1WAC RAS.002", "RASPADOR DUO 750X75", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1XAC RE0.140", "ESCUADRA REBALSE DE LOSA H=140", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1XCA RE0.150", "ESCUADRA REBALSE DE LOSA H=150", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1XCL A01.000", "CANAL ALINEADOR 100X50X1000", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1XCL A01.500", "CANAL ALINEADOR 100X50X1500", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1XCL A01.650", "CAJA ASCENSOR - CANAL ALINEADOR 100X50X1650", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1XCL A02.000", "CANAL ALINEADOR 100X50X2000", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1XCL A02.500", "CANAL ALINEADOR 100X50X2500", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1XCL A03.000", "CANAL ALINEADOR 100X50X3000", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1XCL A03.500", "CANAL ALINEADOR 100X50X3500", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1XCL A04.000", "CANAL ALINEADOR 100X50X4000", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1XCL A04.500", "CANAL ALINEADOR 100X50X4500", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1XCL A05.000", "CANAL ALINEADOR 100X50X5000", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1XCL A06.000", "CANAL ALINEADOR 100X50X6000", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1XCL APC.001", "CAJA ASCENSOR - CANAL TIPO C DE APOYO", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1XCL D01.500", "CANAL DOBLE 1500", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1XCL D02.000", "CANAL DOBLE 2000", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1XCL D02.500", "CANAL DOBLE 2500", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1XCL D03.000", "CANAL DOBLE 3000", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1XCL DCA.001", "CAJA ASCENSOR - CANAL DOBLE 2500-3500", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1XCL ES1.500", "CANAL ESCUADRA 1500 PIVOTE", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1XCL ESC.001", "ESCUADRA PARA SOBRECIMIENTO", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1XCL ESC.150", "CANAL ESCUADRA 1500X1500", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1XCL ESC.650", "CANAL ESCUADRA 650X650", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1XCL ESC.EXT", "ESCUADRA DOBLE CANAL PLEGADA 1120", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1XCL ESC.INT", "ESCUADRA DOBLE CANAL PLEGADA 550", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1XCL ESC.REF", "ESCUADRA DOBLE CANAL PLEGADA 1120 REFORZADA", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1XCL P00.600", "CANAL DOBLE PLEG. 80X40X5X600", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1XCL P01.000", "CANAL DOBLE PLEG. 80X40X5X1000", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1XCL P01.200", "CANAL DOBLE PLEG. 80X40X5X1200", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1XCL P01.500", "CANAL DOBLE PLEG. 80X40X5X1500", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1XCL P02.000", "CANAL DOBLE PLEG. 80X40X5X2000", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1XCL P02.280", "CANAL DOBLE PLEG. 80X40X5X2280", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1XCL P02.400", "CANAL DOBLE PLEG. 80X40X5X2400", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1XCL P03.000", "CANAL DOBLE PLEG. 80X40X5X3000", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1XCL RE1.500", "CANAL REBALSE 1500", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1XCL RE2.000", "CANAL REBALSE 2000", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1XCL UNI.070", "CANAL DE UNION 70X30X3X90", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1XTB A01.000", "TUBO ANDAMIO 1000", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1XTB A01.500", "TUBO ANDAMIO 1500", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1XTB A02.000", "TUBO ANDAMIO 2000", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1XTB A02.500", "TUBO ANDAMIO 2500", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1XTB A03.000", "TUBO ANDAMIO 3000", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1XTB A03.500", "TUBO ANDAMIO 3500", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1XTB A04.000", "TUBO ANDAMIO 4000", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1XTB A04.500", "TUBO ANDAMIO 4500", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1XTB A05.000", "TUBO ANDAMIO 5000", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1XTB A06.000", "TUBO ANDAMIO 6000", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1XTB AP1.300", "TUBO VERTICAL PASAMANO", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1XTB TC1.000", "TUBO ANDAMIO CURVO 1000", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1XTB TC1.500", "TUBO ANDAMIO CURVO 1500", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1XTB TC2.000", "TUBO ANDAMIO CURVO 2000", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1XTB TC2.500", "TUBO ANDAMIO CURVO 2500", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1XTB TC3.000", "TUBO ANDAMIO CURVO 3000", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1XTB TC3.500", "TUBO ANDAMIO CURVO 3500", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1XTB TC4.000", "TUBO ANDAMIO CURVO 4000", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1XTB TC4.500", "TUBO ANDAMIO CURVO 4500", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1XTB TC5.000", "TUBO ANDAMIO CURVO 5000", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "1XTB TC6.000", "TUBO ANDAMIO CURVO 6000", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "901ALZ.002", "MACHO ALZAPRIMA FONDO VIGA 2000", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "901ALZ.003", "MACHO ALZAPRIMA FONDO VIGA 1750", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "901ALZ.004", "MACHO ALZAPRIMA LOSA 2000", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "901ALZ.005", "MACHO ALZAPRIMA LOSA 2600", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "901ALZ.007", "HEMBRA ALZAPRIMA", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "901ALZ.010", "COLLAR ALZAPRIMA - APLOMADOR", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "901APL.001", "MACHO APLOMADOR - ALL STEEL", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "901APL.002", "BASE APLOMADOR - ALL STEEL", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "901APL.003", "PASADOR ALZAPRIMA - APLOMADOR", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "901APL.008", "HEMBRA APLOMADOR ALL STEEL 1000", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "901APL.009", "MACHO APLOMADOR ALL STEEL 1000", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "901APL.010", "MINIMAG APLOMADOR HEMBRA 2000", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "901APL.011", "MACHO APLOMADOR MAGNUM 2000", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "901APL.013", "MINIMAG BRAZO HEMBRA", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "901APL.014", "MACHO APLOMADOR MAGNUM 1100", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "901APL.015", "MINIMAG BRAZO COLLAR PASADOR", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "901CGJ.001", "CABEZA GATA J", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "901CGM.001", "CABEZA GATA MULTIVIA", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "901CGU.001", "CABEZA GATA U", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "901COM.001", "PERNO COPLA GIRATORIA", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "901COM.023", "MINIMAG APLOMADOR BASE", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "901COM.025", "CABEZA APLOMADOR MAGNUM", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "901ROL.001", "BRAZO CORTO L=1015 ROLL BACK (2 Unid.)", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "901ROL.002", "BRAZO EXTENSIBLE L=2010 ROLL B (1 Unid.)", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "901ROL.003", "BRAZO LARGO L=2050 ROLL BACK (1 Unid.)", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "901ROL.004", "CHAVETA PARTIDA 1/4 X 2 (1 Unid.)", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "901ROL.005", "CUÑA GRANDE 430X50 ROLL BACK (2 Unid.)", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "901ROL.006", "DOBLE CANAL 200X60 L= 4060 ROLL BACK (1 Unid.)", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "901ROL.007", "MENSULA TREPANTE ROLL BACK (1 Unid.)", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "901ROL.008", "PASADOR M25X120 ROLL BACK (6 Unid.)", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "901ROL.009", "PASADOR M25X150 ROLL BACK (2 Unid.)", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "901ROL.010", "PASADOR M25X160 ROLL BACK (se verificara ubicacion", 0, 0, 0 });
            DtSalida.Rows.Add(new Object[] { "901ROL.011", "RODILLO ACERO � 70X65 (1 Unid.)", 0, 0, 0 });


            DtSalida.AcceptChanges();


            /*
             					M2
             
             */
            return DtSalida;



        }


        private DataSet GetDataSet(String StrJsonInput)
        {

            var ds = new DataSet();
            try
            {

                ds = JsonConvert.DeserializeObject<DataSet>(StrJsonInput);

            }
            catch (Exception)
            {

                throw;
            }


            return ds;
        }



  


        private void GeneraExcel(string StrFilename)
        {


            var workbook = new XLWorkbook();
            var ws = workbook.Worksheets.Add(DsetReport.Tables[0]);
           



            //formulas por reporte 
            switch (StrFilename)
            {
                case "StockedItemCost_CL.xlsx":
                    DataTable DtArea = GetDtArea();
                    var ws2 = workbook.Worksheets.Add(DtArea);
                    //workbook.Worksheets.Add(DsetReport);
                    #region  StockedItemCost_CL
                    int IntColumnas = 0;
                    int IntFilas = 0;

                    IntColumnas = DsetReport.Tables[0].Columns.Count;
                    IntFilas = DsetReport.Tables[0].Rows.Count;
                    IntFilas = IntFilas + 2;

                    //Primera Columna de formula
                    ws.Cell(1, 11).Value = "$ Renta";
                    ws.Cell(1, 12).Value = "$ En Bodega";

                    ws.Cell(1, 13).Value = "$ Total";
                    ws.Cell(1, 14).Value = "$ Porcentaje";

                    ws.Cell(1, 15).Value = "$ Kg Unit";
                    ws.Cell(1, 16).Value = "$ Kg en renta";
                    ws.Cell(1, 17).Value = "$ Kg en bodega";

                    ws.Cell(1, 18).Value = "$ Kg total";

                    ws.Cell(1, 19).Value = "$ m2 Unit";
                    ws.Cell(1, 20).Value = "$ m2 en Renta";

                    ws.Cell(1, 21).Value = "$ m2 en bodega";
                    ws.Cell(1, 22).Value = "$ M2 total ";
                    ws.Cell(1, 23).Value = "$ Total U ";

                    ws.Cell(1, 24).Value = "0,7";
                    ws.Cell(1, 24).Style.NumberFormat.NumberFormatId = 2;

                    ws.Cell(1, 25).Value = "$ Falta ";
                    ws.Cell(1, 26).Value = "$ Comprar";
                    ws.Cell(1, 27).Value = "$ Sobra ";
                    ws.Cell(1, 28).Value = "$ Vender";



                    for (int i = 2; i < IntFilas; i++)
                    {
                        var cellWithFormulaA1 = ws.Cell(i, 11);
                        string Formula = "=F" + i.ToString() + "*E" + i.ToString() + "";
                        cellWithFormulaA1.FormulaA1 = Formula;
                        cellWithFormulaA1.Style.NumberFormat.NumberFormatId = 3;

                        var cellWithFormula12 = ws.Cell(i, 12);
                        Formula = "=(G" + i.ToString() + " + I" + i.ToString() + " + H" + i.ToString() + " + J" + i.ToString() + ") *$E" + i.ToString() + "";
                        cellWithFormula12.FormulaA1 = Formula;
                        cellWithFormula12.Style.NumberFormat.NumberFormatId = 3;


                        var cellWithFormula13 = ws.Cell(i, 13);
                        Formula = "=K" + i.ToString() + "+L" + i.ToString() + "";
                        cellWithFormula13.FormulaA1 = Formula;
                        cellWithFormula13.Style.NumberFormat.NumberFormatId = 3;

                        var cellWithFormula14 = ws.Cell(i, 14);
                        Formula = "=IF(M" + i.ToString() + "=0,0,K" + i.ToString() + "/M" + i.ToString() + ")"; //  "IFERROR(K" + i.ToString() + "/M" + i.ToString() + ";0)";
                        cellWithFormula14.FormulaA1 = Formula;
                        cellWithFormula14.Style.NumberFormat.NumberFormatId = 9;

                        var cellWithFormula15 = ws.Cell(i, 15);
                        Formula = "=+D" + i.ToString();
                        cellWithFormula15.FormulaA1 = Formula;
                        cellWithFormula15.Style.NumberFormat.NumberFormatId = 3;

                        var cellWithFormula16 = ws.Cell(i, 16);
                        Formula = "=+O" + i.ToString() + "*F" + i.ToString();
                        cellWithFormula16.FormulaA1 = Formula;
                        cellWithFormula16.Style.NumberFormat.NumberFormatId = 3;

                        var cellWithFormula17 = ws.Cell(i, 17);
                        Formula = "=+O" + i.ToString() + "*(G" + i.ToString() + "+H" + i.ToString() + "+I" + i.ToString() + "+J" + i.ToString() + ")";
                        cellWithFormula17.FormulaA1 = Formula;
                        cellWithFormula17.Style.NumberFormat.NumberFormatId = 3;

                        var cellWithFormula18 = ws.Cell(i, 18);
                        Formula = "=+Q" + i.ToString() + "+P" + i.ToString() + "";
                        cellWithFormula18.FormulaA1 = Formula;
                        cellWithFormula18.Style.NumberFormat.NumberFormatId = 3;

                        var cellWithFormula19 = ws.Cell(i, 19);
                        Formula = "";




                        // "=BUSCARV(A3;area!A$2:F$1000;6;FALSO)";
                        //cellWithFormula19.FormulaA1 = Formula;
                        //cellWithFormula19.Style.NumberFormat.NumberFormatId = 3;

                        double dblM2 = 0;

                        string StrQuery = "";
                        string Strcodigo = "";
                        var TempCel = ws.Cell(i, 1);
                        Strcodigo = TempCel.Value.ToString();
                        StrQuery = "Codigo = '" + Strcodigo + "'";
                        DataRow[] result = DtArea.Select(StrQuery);
                        if (result.Length > 0)
                        {

                            double.TryParse(result[0].ItemArray[4].ToString(), out dblM2);

                            if (dblM2 > 0)
                            {
                                cellWithFormula19.Value = dblM2;
                            }

                        }


                        cellWithFormula19.SetDataType(XLDataType.Number);
                        cellWithFormula19.Style.NumberFormat.NumberFormatId = 4;

                        //Esto fue el reemplazo del buscarV 



                        var cellWithFormula20 = ws.Cell(i, 20);
                        Formula = "=+S" + i.ToString() + "*F" + i.ToString() + "";
                        cellWithFormula20.FormulaA1 = Formula;
                        cellWithFormula20.Style.NumberFormat.NumberFormatId = 3;

                        var cellWithFormula21 = ws.Cell(i, 21);
                        Formula = "=+S" + i.ToString() + "*(G" + i.ToString() + "+H" + i.ToString() + "+I" + i.ToString() + "+J" + i.ToString() + ")";
                        cellWithFormula21.FormulaA1 = Formula;
                        cellWithFormula21.Style.NumberFormat.NumberFormatId = 3;

                        var cellWithFormula22 = ws.Cell(i, 22);
                        Formula = "=+U" + i.ToString() + "+T" + i.ToString() + "";
                        cellWithFormula22.FormulaA1 = Formula;
                        cellWithFormula22.Style.NumberFormat.NumberFormatId = 3;


                        var cellWithFormula23 = ws.Cell(i, 23);
                        Formula = "=+F" + i.ToString() + "+G" + i.ToString() + "+H" + i.ToString() + "+I" + i.ToString() + "+J" + i.ToString() + "";
                        cellWithFormula23.FormulaA1 = Formula;
                        cellWithFormula23.Style.NumberFormat.NumberFormatId = 3;


                        var cellWithFormula24 = ws.Cell(i, 24);
                        Formula = "=INT(F" + i.ToString() + "/X$1)*(1)";
                        cellWithFormula24.FormulaA1 = Formula;
                        cellWithFormula24.Style.NumberFormat.NumberFormatId = 3;


                        var cellWithFormula25 = ws.Cell(i, 25);
                        Formula = "=IF(+X" + i.ToString() + "-F" + i.ToString() + "-G" + i.ToString() + "-H" + i.ToString() + "-I" + i.ToString() + "-J" + i.ToString() + ">0,X" + i.ToString() + "-F" + i.ToString() + "-G" + i.ToString() + "-H" + i.ToString() + "-I" + i.ToString() + "-J" + i.ToString() + ",0)";

                        //Formula = "=IF(+X4-F4-G4-H4-I4-J4>0,X4-F4-G4-H4-I4-J4,0)";

                        cellWithFormula25.FormulaA1 = Formula;
                        cellWithFormula25.Style.NumberFormat.NumberFormatId = 3;

                        var cellWithFormula26 = ws.Cell(i, 26);
                        Formula = "=Y" + i.ToString() + "*E" + i.ToString() + "";
                        cellWithFormula26.FormulaA1 = Formula;
                        cellWithFormula26.Style.NumberFormat.NumberFormatId = 3;


                        var cellWithFormula27 = ws.Cell(i, 27);
                        Formula = "=IF(X" + i.ToString() + "-F" + i.ToString() + "-G" + i.ToString() + "-H" + i.ToString() + "-I" + i.ToString() + "-J" + i.ToString() + "<0,-(X" + i.ToString() + "-F" + i.ToString() + "-G" + i.ToString() + "-H" + i.ToString() + "-I" + i.ToString() + "-J" + i.ToString() + "),0)";
                        cellWithFormula27.FormulaA1 = Formula;
                        cellWithFormula27.Style.NumberFormat.NumberFormatId = 3;


                        var cellWithFormula28 = ws.Cell(i, 28);
                        Formula = "=+AA" + i.ToString() + "*E" + i.ToString() + "";
                        cellWithFormula28.FormulaA1 = Formula;
                        cellWithFormula28.Style.NumberFormat.NumberFormatId = 3;


                        if (i == (IntFilas - 1))
                        {
                            int FinalData = IntFilas - 1;
                            int PosFormula = IntFilas;
                            var cellWithFormula_1 = ws.Cell(PosFormula, 6);
                            Formula = "=SUM(F2:F" + FinalData.ToString() + ")";
                            cellWithFormula_1.FormulaA1 = Formula;
                            cellWithFormula_1.Style.NumberFormat.NumberFormatId = 3;


                            Formula = "=SUM(G2:G" + FinalData.ToString() + ")";
                            ws.Cell(PosFormula, 7).FormulaA1 = Formula;
                            ws.Cell(PosFormula, 7).Style.NumberFormat.NumberFormatId = 3;

                            Formula = "=SUM(H2:H" + FinalData.ToString() + ")";
                            ws.Cell(PosFormula, 8).FormulaA1 = Formula;
                            ws.Cell(PosFormula, 8).Style.NumberFormat.NumberFormatId = 3;

                            Formula = "=SUM(I2:I" + FinalData.ToString() + ")";
                            ws.Cell(PosFormula, 9).FormulaA1 = Formula;
                            ws.Cell(PosFormula, 9).Style.NumberFormat.NumberFormatId = 3;

                            Formula = "=SUM(J2:J" + FinalData.ToString() + ")";
                            ws.Cell(PosFormula, 10).FormulaA1 = Formula;
                            ws.Cell(PosFormula, 10).Style.NumberFormat.NumberFormatId = 3;

                            Formula = "=SUM(K2:K" + FinalData.ToString() + ")";
                            ws.Cell(PosFormula, 11).FormulaA1 = Formula;
                            ws.Cell(PosFormula, 11).Style.NumberFormat.NumberFormatId = 3;


                            Formula = "=SUM(L2:L" + FinalData.ToString() + ")";
                            ws.Cell(PosFormula, 12).FormulaA1 = Formula;
                            ws.Cell(PosFormula, 12).Style.NumberFormat.NumberFormatId = 3;


                            Formula = "=SUM(M2:M" + FinalData.ToString() + ")";
                            ws.Cell(PosFormula, 13).FormulaA1 = Formula;
                            ws.Cell(PosFormula, 13).Style.NumberFormat.NumberFormatId = 3;

                            //Formula qUENO SUMA 
                            Formula = "=IF(M" + PosFormula.ToString() + "=0,0,K" + PosFormula.ToString() + "/M" + PosFormula.ToString() + ")";
                            //=SI.ERROR(K800/M800;0)
                            ws.Cell(PosFormula, 14).FormulaA1 = Formula;
                            ws.Cell(PosFormula, 14).Style.NumberFormat.NumberFormatId = 9;

                            Formula = "=SUM(O2:O" + FinalData.ToString() + ")";
                            ws.Cell(PosFormula, 15).FormulaA1 = Formula;
                            ws.Cell(PosFormula, 15).Style.NumberFormat.NumberFormatId = 3;

                            Formula = "=SUM(P2:P" + FinalData.ToString() + ")";
                            ws.Cell(PosFormula, 16).FormulaA1 = Formula;
                            ws.Cell(PosFormula, 16).Style.NumberFormat.NumberFormatId = 3;

                            Formula = "=SUM(Q2:Q" + FinalData.ToString() + ")";
                            ws.Cell(PosFormula, 17).FormulaA1 = Formula;
                            ws.Cell(PosFormula, 17).Style.NumberFormat.NumberFormatId = 3;

                            Formula = "=SUM(R2:R" + FinalData.ToString() + ")";
                            ws.Cell(PosFormula, 18).FormulaA1 = Formula;
                            ws.Cell(PosFormula, 18).Style.NumberFormat.NumberFormatId = 3;

                            Formula = "=SUM(S2:S" + FinalData.ToString() + ")";
                            ws.Cell(PosFormula, 19).FormulaA1 = Formula;
                            ws.Cell(PosFormula, 19).Style.NumberFormat.NumberFormatId = 3;

                            Formula = "=SUM(T2:T" + FinalData.ToString() + ")";
                            ws.Cell(PosFormula, 20).FormulaA1 = Formula;
                            ws.Cell(PosFormula, 20).Style.NumberFormat.NumberFormatId = 3;

                            Formula = "=SUM(U2:U" + FinalData.ToString() + ")";
                            ws.Cell(PosFormula, 21).FormulaA1 = Formula;
                            ws.Cell(PosFormula, 21).Style.NumberFormat.NumberFormatId = 3;

                            Formula = "=SUM(V2:V" + FinalData.ToString() + ")";
                            ws.Cell(PosFormula, 22).FormulaA1 = Formula;
                            ws.Cell(PosFormula, 22).Style.NumberFormat.NumberFormatId = 3;

                            Formula = "=SUM(W2:W" + FinalData.ToString() + ")";
                            ws.Cell(PosFormula, 23).FormulaA1 = Formula;
                            ws.Cell(PosFormula, 23).Style.NumberFormat.NumberFormatId = 3;

                            Formula = "=SUM(X2:X" + FinalData.ToString() + ")";
                            ws.Cell(PosFormula, 24).FormulaA1 = Formula;
                            ws.Cell(PosFormula, 24).Style.NumberFormat.NumberFormatId = 3;

                            Formula = "=SUM(Y2:Y" + FinalData.ToString() + ")";
                            ws.Cell(PosFormula, 25).FormulaA1 = Formula;
                            ws.Cell(PosFormula, 25).Style.NumberFormat.NumberFormatId = 3;

                            Formula = "=SUM(Z2:Z" + FinalData.ToString() + ")";
                            ws.Cell(PosFormula, 26).FormulaA1 = Formula;
                            ws.Cell(PosFormula, 26).Style.NumberFormat.NumberFormatId = 3;


                            Formula = "=SUM(AA2:AA" + FinalData.ToString() + ")";
                            ws.Cell(PosFormula, 27).FormulaA1 = Formula;
                            ws.Cell(PosFormula, 27).Style.NumberFormat.NumberFormatId = 3;


                            Formula = "=SUM(AB2:AB" + FinalData.ToString() + ")";
                            ws.Cell(PosFormula, 28).FormulaA1 = Formula;
                            ws.Cell(PosFormula, 28).Style.NumberFormat.NumberFormatId = 3;








                        }
                    }


                    //formateo de las 28 col
                    int cols = 28;
                    for (int i = 1; i <= cols; i++)
                    {
                        /*
                        $ En Bodega	$ Total	$ Porcentaje	$ Kg Unit	$ Kg en renta	$ Kg en bodega	$ Kg total	$ m2 Unit	$ m2 en Renta	$ m2 en bodega	$ M2 total 	$ Total U 	0,70	$ Falta 	$ Comprar	$ Sobra 	$ Vender
                        */
                        ws.Column(i).AdjustToContents();

                        //Totales 
                        // var cellWithFormula27 = ws.Cell(i,IntFilas+1);
                    }

                    string tmpForm = "";
                    var cellWithFormula = ws.Cell(6, 777);

                  


                    #endregion
                break;

                case "StockedItemCostCostumer_CL.xlsx":
                    #region StockedItemCost_CL


                    int intLargoTabla = 0;
                    intLargoTabla = DsetReport.Tables[0].Rows.Count;

                    for (int i = 2; i < intLargoTabla; i++)
                    {
                        var cellWithFormula20 = ws.Cell(i, 5);
                        cellWithFormula20.SetDataType(XLDataType.Number);
                        cellWithFormula20.Style.NumberFormat.NumberFormatId = 4;

                


                        var cellWithFormula21 = ws.Cell(i, 6);
                        cellWithFormula21.SetDataType(XLDataType.Number);
                        cellWithFormula21.Style.NumberFormat.NumberFormatId = 4;


                    }


                



                    #endregion


                    break;


            }



            // Prepare the response
            HttpResponse httpResponse = Response;
            httpResponse.Clear();
            httpResponse.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            httpResponse.AddHeader("content-disposition", "attachment;filename=\"" + StrFilename + "\"");

            // Flush the workbook to the Response.OutputStream
            using (MemoryStream memoryStream = new MemoryStream())
            {
                workbook.SaveAs(memoryStream);
                memoryStream.WriteTo(httpResponse.OutputStream);
                memoryStream.Close();
            }

            httpResponse.End();

        }


        protected void BtnExcel_Click(object sender, EventArgs e)
        {
            String StrFilename = "Filename";
            StrFilename = ddlReporte.SelectedValue;


            switch (StrFilename)
            {
                case "StockedItemCost":

                    StrFilename = "StockedItemCost_CL.xlsx";
                    StrJsonReport = Wsneed.GetProductoReport("cl", "consultaweb", "Unispan.001");
                    DsetReport = GetDataSet(StrJsonReport);
                    GeneraExcel(StrFilename);

                    break;

                case "StockedItemCostCostumer":

                    StrFilename = "StockedItemCostCostumer_CL.xlsx";
                    StrJsonReport = Wsneed.GetReportCustomerSL("cl", "consultaweb", "Unispan.001");
                    DsetReport = GetDataSet(StrJsonReport);
                    GeneraExcel(StrFilename);
                    break;

                case "demo":
                    var wb = new XLWorkbook();
                    var ws = wb.Worksheets.Add("Formulas");

                    ws.Cell(1, 1).Value = "Num1";
                    ws.Cell(1, 2).Value = "Num2";
                    ws.Cell(1, 3).Value = "Total";
                    ws.Cell(1, 4).Value = "cell.FormulaA1";
                    ws.Cell(1, 5).Value = "cell.FormulaR1C1";
                    ws.Cell(1, 6).Value = "cell.Value";
                    ws.Cell(1, 7).Value = "Are Equal?";

                    ws.Cell(2, 1).Value = 1;
                    ws.Cell(2, 2).Value = 2;
                    var cellWithFormulaA1 = ws.Cell(2, 3);
                    // Use A1 notation
                    cellWithFormulaA1.FormulaA1 = "=A2+$B$2"; // The equal sign (=) in a formula is optional
                    ws.Cell(2, 4).Value = cellWithFormulaA1.FormulaA1;
                    ws.Cell(2, 5).Value = cellWithFormulaA1.FormulaR1C1;

                    ws.Cell(2, 6).Value = cellWithFormulaA1.Value;

                    ws.Cell(3, 1).Value = 1;
                    ws.Cell(3, 2).Value = 2;
                    var cellWithFormulaR1C1 = ws.Cell(3, 3);
                    // Use R1C1 notation
                    cellWithFormulaR1C1.FormulaR1C1 = "RC[-2]+R3C2"; // The equal sign (=) in a formula is optional
                    ws.Cell(3, 4).Value = cellWithFormulaR1C1.FormulaA1;
                    ws.Cell(3, 5).Value = cellWithFormulaR1C1.FormulaR1C1;
                    ws.Cell(3, 6).Value = cellWithFormulaR1C1.Value;

                    ws.Cell(4, 1).Value = "A";
                    ws.Cell(4, 2).Value = "B";
                    var cellWithStringFormula = ws.Cell(4, 3);

                    // Use R1C1 notation
                    cellWithStringFormula.FormulaR1C1 = "=\"Test\" & RC[-2] & \"R3C2\"";
                    ws.Cell(4, 4).Value = cellWithStringFormula.FormulaA1;
                    ws.Cell(4, 5).Value = cellWithStringFormula.FormulaR1C1;
                    ws.Cell(4, 6).Value = cellWithStringFormula.Value;

                    // Setting the formula of a range
                    var rngData = ws.Range(2, 1, 4, 7);
                    rngData.LastColumn().FormulaR1C1 = "=IF(RC[-3]=RC[-1],\"Yes\", \"No\")";

                    // Using an array formula:
                    // Just put the formula between curly braces
                    ws.Cell("A6").Value = "Array Formula: ";
                    ws.Cell("B6").FormulaA1 = "{A2+A3}";

                    ws.Range(1, 1, 1, 7).Style.Fill.BackgroundColor = XLColor.Cyan;
                    ws.Range(1, 1, 1, 7).Style.Font.Bold = true;
                    ws.Columns().AdjustToContents();

                    // You can also change the reference notation:
                    wb.ReferenceStyle = XLReferenceStyle.R1C1;

                    // And the workbook calculation mode:
                    wb.CalculateMode = XLCalculateMode.Auto;

                    //wb.SaveAs("Formulas.xlsx");

                    // Prepare the response
                    HttpResponse httpResponse = Response;
                    httpResponse.Clear();
                    httpResponse.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                    httpResponse.AddHeader("content-disposition", "attachment;filename=\"" + "demo.xlsx" + "\"");

                    // Flush the workbook to the Response.OutputStream
                    using (MemoryStream memoryStream = new MemoryStream())
                    {
                        wb.SaveAs(memoryStream);
                        memoryStream.WriteTo(httpResponse.OutputStream);
                        memoryStream.Close();
                    }

                    httpResponse.End();

                    break;


            }

            //llamr a GeneraExcel






        }
    }
}