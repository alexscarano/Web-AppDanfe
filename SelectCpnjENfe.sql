USE Eproc_121;


/*SELECT Nfe.nfe FROM dbo.NotaFiscalEletronica Nfe
WHERE Nfe.cnpjEmitente = '05494486000185'
AND Nfe.numeroNFe = '81794';*/

 SELECT Nfe.cnpjEmitente, Nfe.numeroNFe, Nfe.nfe FROM dbo.NotaFiscalEletronica Nfe;