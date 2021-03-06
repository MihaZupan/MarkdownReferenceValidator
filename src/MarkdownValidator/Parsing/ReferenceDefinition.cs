﻿/*
    Copyright (c) 2018 Miha Zupan. All rights reserved.
    This file is a part of the Markdown Validator project
    It is licensed under the Simplified BSD License (BSD 2-clause).
    For more information visit:
    https://github.com/MihaZupan/MarkdownValidator/blob/master/LICENSE
*/
using Markdig.Syntax;
using System;
using System.Diagnostics;

namespace MihaZupan.MarkdownValidator.Parsing
{
    [DebuggerDisplay("{GlobalReference} on line {Line}")]
    internal class ReferenceDefinition : Reference, IEquatable<ReferenceDefinition>
    {
        public readonly MarkdownFile SourceFile;
        public bool Used = false;

        public ReferenceDefinition(string reference, string globalReference, SourceSpan span, int line, MarkdownFile sourceFile)
            : base(reference, globalReference, span, line)
        {
            SourceFile = sourceFile;
        }
        public ReferenceDefinition(string reference, string globalReference, MarkdownObject markdownObject, MarkdownFile sourceFile)
            : base(reference, globalReference, markdownObject.Span, markdownObject.Line)
        {
            SourceFile = sourceFile;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (obj is ReferenceDefinition definition)
            {
                return Equals(definition);
            }
            return false;
        }
        public bool Equals(ReferenceDefinition other)
        {
            return other.Equals(this as Reference) && ReferenceEquals(SourceFile, other.SourceFile);
        }
    }
}
