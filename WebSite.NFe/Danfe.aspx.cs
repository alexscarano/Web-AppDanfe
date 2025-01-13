using NFe.Danfe.Html;
using NFe.Danfe.Html.CrossCutting;
using NFe.Danfe.Html.Interfaces;
using System;
using System.Collections.Generic;
public partial class Danfe : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ObterDanfeNfe();


    }

    public void ObterDanfeNfe()
    {
        var listNfe = new List<string>();

        string xmlString1 = @"<?xml version=""1.0"" encoding=""UTF-8""?>
            <NFe xmlns=""http://www.portalfiscal.inf.br/nfe"">
            <infNFe versao=""4.00"" Id=""NFe"">
                <ide>
                <cUF>35</cUF>
                <cNF>00000000</cNF>
                <natOp>venda</natOp>
                <mod>55</mod>
                <serie>0</serie>
                <nNF>0</nNF>
                <dhEmi>2024-12-02T18:34:00-03:00</dhEmi>
                <dhSaiEnt>2024-12-02T18:34:00-03:00</dhSaiEnt>
                <tpNF>1</tpNF>
                <idDest>1</idDest>
                <cMunFG>3550308</cMunFG>
                <tpImp>1</tpImp>
                <tpEmis>1</tpEmis>
                <cDV>0</cDV>
                <tpAmb>1</tpAmb>
                <finNFe>1</finNFe>
                <indFinal>0</indFinal>
                <indPres>1</indPres>
                <procEmi>0</procEmi>
                <verProc>4.00</verProc>
                </ide>
                <emit>
                <CNPJ>51501045000180</CNPJ>
                <xNome>TAPPO GASTRONOMIA LTDA</xNome>
                <xFant>TAPPO GASTRONOMIA</xFant>
                <enderEmit>
                    <xLgr>RUA ALAGOAS</xLgr>
                    <nro>475</nro>
                    <xCpl>TERREOSALAO</xCpl>
                    <xBairro>HIGIENOPOLIS</xBairro>
                    <cMun>3550308</cMun>
                    <xMun>Sao Paulo</xMun>
                    <UF>SP</UF>
                    <CEP>01242901</CEP>
                    <cPais>1058</cPais>
                    <xPais>BRASIL</xPais>
                </enderEmit>
                <IE>124531503115</IE>
                <CRT>3</CRT>
                </emit>
                <dest>
                <CPF>00000000000</CPF>
                <xNome>Ricardo</xNome>
                <enderDest>
                    <xLgr>Rua A</xLgr>
                    <nro>200</nro>
                    <xBairro>Bairro</xBairro>
                    <cMun>3136702</cMun>
                    <xMun>Juiz de Fora</xMun>
                    <UF>MG</UF>
                    <CEP>36000000</CEP>
                    <cPais>1058</cPais>
                    <xPais>Brasil</xPais>
                </enderDest>
                <indIEDest>1</indIEDest>
                </dest>
                <det nItem=""1"">
                <prod>
                    <cProd>00002</cProd>
                    <cEAN />
                    <xProd>COCA COLA</xProd>
                    <NCM>22021000</NCM>
                    <CFOP>2002</CFOP>
                    <uCom>un</uCom>
                    <qCom>1.0000</qCom>
                    <vUnCom>8.0000000000</vUnCom>
                    <vProd>8.00</vProd>
                    <cEANTrib />
                    <uTrib>un</uTrib>
                    <qTrib>1.0000</qTrib>
                    <vUnTrib>8.0000000000</vUnTrib>
                    <indTot>1</indTot>
                    <xPed>2</xPed>
                    <nItemPed>1</nItemPed>
                </prod>
                <imposto>
                    <ICMS>
                    <ICMS40>
                        <orig>4</orig>
                        <CST>40</CST>
                    </ICMS40>
                    </ICMS>
                    <IPI>
                    <cEnq>999</cEnq>
                    <IPINT>
                        <CST>53</CST>
                    </IPINT>
                    </IPI>
                    <PIS>
                    <PISOutr>
                        <CST>54</CST>
                        <vBC>8.00</vBC>
                        <pPIS>3.00</pPIS>
                        <vPIS>0.24</vPIS>
                    </PISOutr>
                    </PIS>
                    <PISST>
                    <vBC>8.00</vBC>
                    <pPIS>2.00</pPIS>
                    <vPIS>0.16</vPIS>
                    </PISST>
                    <COFINS>
                    <COFINSOutr>
                        <CST>55</CST>
                        <vBC>8.00</vBC>
                        <pCOFINS>3.00</pCOFINS>
                        <vCOFINS>0.24</vCOFINS>
                    </COFINSOutr>
                    </COFINS>
                    <COFINSST>
                    <vBC>8.00</vBC>
                    <pCOFINS>2.00</pCOFINS>
                    <vCOFINS>0.16</vCOFINS>
                    </COFINSST>
                </imposto>
                </det>
                <total>
                <ICMSTot>
                    <vBC>0.00</vBC>
                    <vICMS>0.00</vICMS>
                    <vICMSDeson>0.00</vICMSDeson>
                    <vFCP>0.00</vFCP>
                    <vBCST>0.00</vBCST>
                    <vST>0.00</vST>
                    <vFCPST>0.00</vFCPST>
                    <vFCPSTRet>0.00</vFCPSTRet>
                    <vProd>8.00</vProd>
                    <vFrete>0.00</vFrete>
                    <vSeg>0.00</vSeg>
                    <vDesc>0.00</vDesc>
                    <vII>0.00</vII>
                    <vIPI>0.00</vIPI>
                    <vIPIDevol>0.00</vIPIDevol>
                    <vPIS>0.24</vPIS>
                    <vCOFINS>0.24</vCOFINS>
                    <vOutro>0.00</vOutro>
                    <vNF>8.00</vNF>
                </ICMSTot>
                </total>
                <transp>
                <modFrete>1</modFrete>
                <transporta>
                    <xNome>ANDRE RAZUK</xNome>
                    <xMun>-</xMun>
                    <UF>MG</UF>
                </transporta>
                <veicTransp>
                    <placa>ahj4567</placa>
                    <UF>MG</UF>
                </veicTransp>
                <vol>
                    <qVol>1</qVol>
                    <esp>asdf</esp>
                    <marca>sadf</marca>
                    <nVol>1</nVol>
                    <pesoL>1.000</pesoL>
                    <pesoB>1.000</pesoB>
                </vol>
                </transp>
                <pag>
                <detPag>
                    <indPag>0</indPag>
                    <tPag>01</tPag>
                    <vPag>8.56</vPag>
                </detPag>
                </pag>
            </infNFe>
            </NFe>";

        listNfe.Add(xmlString1);

        foreach (var item in listNfe)
        {
            
            
            var nfe = Utils.XmlStringParaClasse<NFe.Classes.NFe>(item);
            var danfe = new NFe.Danfe.Html.Dominio.DanfeNFe(nfe, Status.Autorizada, "51501045000180", "Emissor Fiscal DSBR Brasil - www.dsbrbrasil.com.br");

            DanfeNfeHtml2 d1 = new DanfeNfeHtml2(danfe);
            var doc = d1.ObterDocHtmlAsync();
            var nomeArquivo = $"danfe {nfe.infNFe.Id}.html";
            Utils.DelatarArquivo(@"C:\Users\alexa\OneDrive\Documents\Alexandre\dotnet\Repos\Danfe_View\", nomeArquivo);
            Utils.EscreverArquivo(@"C:\Users\alexa\OneDrive\Documents\Alexandre\dotnet\Repos\Danfe_View\", nomeArquivo, doc.Html);

        }
    }

}