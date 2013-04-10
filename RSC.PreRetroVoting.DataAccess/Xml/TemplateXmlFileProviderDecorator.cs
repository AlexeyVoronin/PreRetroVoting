using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RSC.PreRetroVoting.DataAccess.FileSystem;

namespace RSC.PreRetroVoting.DataAccess.Xml
{
  internal sealed class TemplateXmlFileProviderDecorator : IXmlFileProvider
  {
    public TemplateXmlFileProviderDecorator(
      IXmlFileProvider baseFileProvider, 
      IFileOperations fileOperations,
      string fileTemplate,
      string fileName)
    {
      _baseFileProvider = baseFileProvider;
      _fileOperations = fileOperations;
      _fileTemplate = fileTemplate;
      _fileName = fileName;
    }

    #region IXmlFileProvider Members

    public IXmlFile OpenXmlFile()
    {
      if (!_fileOperations.IsFileExists(_fileName))
      {
        _fileOperations.WriteAllTextToFile(_fileName, _fileTemplate);
      }

      return _baseFileProvider.OpenXmlFile();
    }

    #endregion

    private readonly IXmlFileProvider _baseFileProvider;
    private readonly IFileOperations _fileOperations;
    private readonly string _fileTemplate;
    private readonly string _fileName;
  }
}
