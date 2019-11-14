<!--
GENERATED FILE - DO NOT EDIT
This file was generated by [MarkdownSnippets](https://github.com/SimonCropp/MarkdownSnippets).
Source File: /docs/ApprovalUtilities/mdsource/readme.source.md
To change this file edit the source file and then execute run_markdown.cmd.
-->

# ApprovalUtilities Features


## Guards

Guards are convenient functions if incorrect values are passed in.

<!-- snippet: guard_usage -->
<a id='snippet-guard_usage'/></a>
```cs
Guard.AgainstNullAndEmpty(subdirectory, nameof(subdirectory));
```
<sup>[snippet source](/src/ApprovalTests/Namers/UseApprovalSubdirectoryAttribute.cs#L10-L12) / [anchor](#snippet-guard_usage)</sup>
<!-- endsnippet -->


## Disposables.Create

`using` statements nicely cleanup on exit if you have a `IDisposable` or you can create a simple disposable object by passing in a lambda.  

<!-- snippet: disposables -->
<a id='snippet-disposables'/></a>
```cs
using (var cleanup = Disposables.Create(() => callCount++))
{
    //code
}
```
<sup>[snippet source](/src/ApprovalUtilities.Tests/Utilities/DisposablesTest.cs#L12-L17) / [anchor](#snippet-disposables)</sup>
<!-- endsnippet -->

---

[Back to User Guide](/doc/README.md#top)