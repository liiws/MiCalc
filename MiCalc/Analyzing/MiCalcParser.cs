// This code was generated by the Gardens Point Parser Generator
// Copyright (c) Wayne Kelly, QUT 2005-2010
// (see accompanying GPPGcopyright.rtf)

// GPPG version 1.5.0
// Machine:  LGT-PC
// DateTime: 19.04.2015 15:38:31
// UserName: lgt
// Input file <MiCalcParser.y - 19.04.2015 15:38:29>

// options: no-lines gplex

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using QUT.Gppg;
using MiCalc.Runtime;

namespace MiCalc.Analyzing
{
public enum Tokens {
    error=1,EOF=2,NUMBER=3,NUMBERBIN=4,NUMBERHEX=5,CONST_PI=6,
    CONST_E=7,FUNC_FLOOR=8,FUNC_CEIL=9,FUNC_ROUND=10,FUNC_SIN=11,FUNC_COS=12,
    FUNC_TAN=13,FUNC_ASIN=14,FUNC_ACOS=15,FUNC_ATAN=16,FUNC_SINH=17,FUNC_COSH=18,
    FUNC_TANG=19,FUNC_ASINH=20,FUNC_ACOSH=21,FUNC_ATANH=22,FUNC_LN=23,FUNC_LG=24,
    FUNC_EXP=25,FUNC_SQRT=26,OP_RIGHT_PAR=27,OP_LEFT_PAR=28,OP_RSH=29,OP_LSH=30,
    OP_ADD=31,OP_SUB=32,OP_MUL=33,OP_DIV=34,OP_MOD=35,OP_OR=36,
    OP_XOR=37,OP_AND=38,OP_NOT=39,OP_POW=40,OP_FAC=41,UMINUS=42,
    UPLUS=43};

public struct ValueType
{
	public string String;
	public Expression expr;
}
// Abstract base class for GPLEX scanners
public abstract class ScanBase : AbstractScanner<ValueType,LexLocation> {
  private LexLocation __yylloc = new LexLocation();
  public override LexLocation yylloc { get { return __yylloc; } set { __yylloc = value; } }
  protected virtual bool yywrap() { return true; }
}

// Utility class for encapsulating token information
public class ScanObj {
  public int token;
  public ValueType yylval;
  public LexLocation yylloc;
  public ScanObj( int t, ValueType val, LexLocation loc ) {
    this.token = t; this.yylval = val; this.yylloc = loc;
  }
}

public class Parser: ShiftReduceParser<ValueType, LexLocation>
{
  // Verbatim content from MiCalcParser.y - 19.04.2015 15:38:29
	public Expression expression = new Expression();
  // End verbatim content from MiCalcParser.y - 19.04.2015 15:38:29

#pragma warning disable 649
  private static Dictionary<int, string> aliasses;
#pragma warning restore 649
  private static Rule[] rules = new Rule[46];
  private static State[] states = new State[120];
  private static string[] nonTerms = new string[] {
      "expression", "$accept", "expr", "func", "stat", "const", };

  static Parser() {
    states[0] = new State(new int[]{28,27,8,31,9,35,10,39,11,43,12,47,13,51,14,55,15,59,16,63,17,67,18,71,19,75,20,79,21,83,22,87,23,91,24,95,25,99,26,103,3,108,4,109,5,110,6,112,7,113,39,114,32,116,31,118},new int[]{-1,1,-3,3,-4,30,-5,107,-6,111});
    states[1] = new State(new int[]{2,2});
    states[2] = new State(-1);
    states[3] = new State(new int[]{31,4,32,6,33,8,34,10,35,12,40,14,38,16,36,18,37,20,29,22,30,24,41,26,2,-2});
    states[4] = new State(new int[]{28,27,8,31,9,35,10,39,11,43,12,47,13,51,14,55,15,59,16,63,17,67,18,71,19,75,20,79,21,83,22,87,23,91,24,95,25,99,26,103,3,108,4,109,5,110,6,112,7,113,39,114,32,116,31,118},new int[]{-3,5,-4,30,-5,107,-6,111});
    states[5] = new State(new int[]{31,-6,32,-6,33,8,34,10,35,12,40,14,38,16,36,18,37,20,29,-6,30,-6,41,26,2,-6,27,-6});
    states[6] = new State(new int[]{28,27,8,31,9,35,10,39,11,43,12,47,13,51,14,55,15,59,16,63,17,67,18,71,19,75,20,79,21,83,22,87,23,91,24,95,25,99,26,103,3,108,4,109,5,110,6,112,7,113,39,114,32,116,31,118},new int[]{-3,7,-4,30,-5,107,-6,111});
    states[7] = new State(new int[]{31,-7,32,-7,33,8,34,10,35,12,40,14,38,16,36,18,37,20,29,-7,30,-7,41,26,2,-7,27,-7});
    states[8] = new State(new int[]{28,27,8,31,9,35,10,39,11,43,12,47,13,51,14,55,15,59,16,63,17,67,18,71,19,75,20,79,21,83,22,87,23,91,24,95,25,99,26,103,3,108,4,109,5,110,6,112,7,113,39,114,32,116,31,118},new int[]{-3,9,-4,30,-5,107,-6,111});
    states[9] = new State(new int[]{31,-8,32,-8,33,-8,34,-8,35,12,40,14,38,16,36,18,37,20,29,-8,30,-8,41,26,2,-8,27,-8});
    states[10] = new State(new int[]{28,27,8,31,9,35,10,39,11,43,12,47,13,51,14,55,15,59,16,63,17,67,18,71,19,75,20,79,21,83,22,87,23,91,24,95,25,99,26,103,3,108,4,109,5,110,6,112,7,113,39,114,32,116,31,118},new int[]{-3,11,-4,30,-5,107,-6,111});
    states[11] = new State(new int[]{31,-9,32,-9,33,-9,34,-9,35,12,40,14,38,16,36,18,37,20,29,-9,30,-9,41,26,2,-9,27,-9});
    states[12] = new State(new int[]{28,27,8,31,9,35,10,39,11,43,12,47,13,51,14,55,15,59,16,63,17,67,18,71,19,75,20,79,21,83,22,87,23,91,24,95,25,99,26,103,3,108,4,109,5,110,6,112,7,113,39,114,32,116,31,118},new int[]{-3,13,-4,30,-5,107,-6,111});
    states[13] = new State(new int[]{31,-10,32,-10,33,-10,34,-10,35,-10,40,14,38,16,36,18,37,20,29,-10,30,-10,41,26,2,-10,27,-10});
    states[14] = new State(new int[]{28,27,8,31,9,35,10,39,11,43,12,47,13,51,14,55,15,59,16,63,17,67,18,71,19,75,20,79,21,83,22,87,23,91,24,95,25,99,26,103,3,108,4,109,5,110,6,112,7,113,39,114,32,116,31,118},new int[]{-3,15,-4,30,-5,107,-6,111});
    states[15] = new State(new int[]{31,-11,32,-11,33,-11,34,-11,35,-11,40,-11,38,-11,36,-11,37,-11,29,-11,30,-11,41,26,2,-11,27,-11});
    states[16] = new State(new int[]{28,27,8,31,9,35,10,39,11,43,12,47,13,51,14,55,15,59,16,63,17,67,18,71,19,75,20,79,21,83,22,87,23,91,24,95,25,99,26,103,3,108,4,109,5,110,6,112,7,113,39,114,32,116,31,118},new int[]{-3,17,-4,30,-5,107,-6,111});
    states[17] = new State(new int[]{31,-12,32,-12,33,-12,34,-12,35,-12,40,14,38,-12,36,-12,37,-12,29,-12,30,-12,41,26,2,-12,27,-12});
    states[18] = new State(new int[]{28,27,8,31,9,35,10,39,11,43,12,47,13,51,14,55,15,59,16,63,17,67,18,71,19,75,20,79,21,83,22,87,23,91,24,95,25,99,26,103,3,108,4,109,5,110,6,112,7,113,39,114,32,116,31,118},new int[]{-3,19,-4,30,-5,107,-6,111});
    states[19] = new State(new int[]{31,-13,32,-13,33,-13,34,-13,35,-13,40,14,38,16,36,-13,37,20,29,-13,30,-13,41,26,2,-13,27,-13});
    states[20] = new State(new int[]{28,27,8,31,9,35,10,39,11,43,12,47,13,51,14,55,15,59,16,63,17,67,18,71,19,75,20,79,21,83,22,87,23,91,24,95,25,99,26,103,3,108,4,109,5,110,6,112,7,113,39,114,32,116,31,118},new int[]{-3,21,-4,30,-5,107,-6,111});
    states[21] = new State(new int[]{31,-15,32,-15,33,-15,34,-15,35,-15,40,14,38,16,36,-15,37,-15,29,-15,30,-15,41,26,2,-15,27,-15});
    states[22] = new State(new int[]{28,27,8,31,9,35,10,39,11,43,12,47,13,51,14,55,15,59,16,63,17,67,18,71,19,75,20,79,21,83,22,87,23,91,24,95,25,99,26,103,3,108,4,109,5,110,6,112,7,113,39,114,32,116,31,118},new int[]{-3,23,-4,30,-5,107,-6,111});
    states[23] = new State(new int[]{31,4,32,6,33,8,34,10,35,12,40,14,38,16,36,18,37,20,29,-16,30,-16,41,26,2,-16,27,-16});
    states[24] = new State(new int[]{28,27,8,31,9,35,10,39,11,43,12,47,13,51,14,55,15,59,16,63,17,67,18,71,19,75,20,79,21,83,22,87,23,91,24,95,25,99,26,103,3,108,4,109,5,110,6,112,7,113,39,114,32,116,31,118},new int[]{-3,25,-4,30,-5,107,-6,111});
    states[25] = new State(new int[]{31,4,32,6,33,8,34,10,35,12,40,14,38,16,36,18,37,20,29,-17,30,-17,41,26,2,-17,27,-17});
    states[26] = new State(-18);
    states[27] = new State(new int[]{28,27,8,31,9,35,10,39,11,43,12,47,13,51,14,55,15,59,16,63,17,67,18,71,19,75,20,79,21,83,22,87,23,91,24,95,25,99,26,103,3,108,4,109,5,110,6,112,7,113,39,114,32,116,31,118},new int[]{-3,28,-4,30,-5,107,-6,111});
    states[28] = new State(new int[]{27,29,31,4,32,6,33,8,34,10,35,12,40,14,38,16,36,18,37,20,29,22,30,24,41,26});
    states[29] = new State(-3);
    states[30] = new State(-4);
    states[31] = new State(new int[]{28,32});
    states[32] = new State(new int[]{28,27,8,31,9,35,10,39,11,43,12,47,13,51,14,55,15,59,16,63,17,67,18,71,19,75,20,79,21,83,22,87,23,91,24,95,25,99,26,103,3,108,4,109,5,110,6,112,7,113,39,114,32,116,31,118},new int[]{-3,33,-4,30,-5,107,-6,111});
    states[33] = new State(new int[]{27,34,31,4,32,6,33,8,34,10,35,12,40,14,38,16,36,18,37,20,29,22,30,24,41,26});
    states[34] = new State(-21);
    states[35] = new State(new int[]{28,36});
    states[36] = new State(new int[]{28,27,8,31,9,35,10,39,11,43,12,47,13,51,14,55,15,59,16,63,17,67,18,71,19,75,20,79,21,83,22,87,23,91,24,95,25,99,26,103,3,108,4,109,5,110,6,112,7,113,39,114,32,116,31,118},new int[]{-3,37,-4,30,-5,107,-6,111});
    states[37] = new State(new int[]{27,38,31,4,32,6,33,8,34,10,35,12,40,14,38,16,36,18,37,20,29,22,30,24,41,26});
    states[38] = new State(-22);
    states[39] = new State(new int[]{28,40});
    states[40] = new State(new int[]{28,27,8,31,9,35,10,39,11,43,12,47,13,51,14,55,15,59,16,63,17,67,18,71,19,75,20,79,21,83,22,87,23,91,24,95,25,99,26,103,3,108,4,109,5,110,6,112,7,113,39,114,32,116,31,118},new int[]{-3,41,-4,30,-5,107,-6,111});
    states[41] = new State(new int[]{27,42,31,4,32,6,33,8,34,10,35,12,40,14,38,16,36,18,37,20,29,22,30,24,41,26});
    states[42] = new State(-23);
    states[43] = new State(new int[]{28,44});
    states[44] = new State(new int[]{28,27,8,31,9,35,10,39,11,43,12,47,13,51,14,55,15,59,16,63,17,67,18,71,19,75,20,79,21,83,22,87,23,91,24,95,25,99,26,103,3,108,4,109,5,110,6,112,7,113,39,114,32,116,31,118},new int[]{-3,45,-4,30,-5,107,-6,111});
    states[45] = new State(new int[]{27,46,31,4,32,6,33,8,34,10,35,12,40,14,38,16,36,18,37,20,29,22,30,24,41,26});
    states[46] = new State(-24);
    states[47] = new State(new int[]{28,48});
    states[48] = new State(new int[]{28,27,8,31,9,35,10,39,11,43,12,47,13,51,14,55,15,59,16,63,17,67,18,71,19,75,20,79,21,83,22,87,23,91,24,95,25,99,26,103,3,108,4,109,5,110,6,112,7,113,39,114,32,116,31,118},new int[]{-3,49,-4,30,-5,107,-6,111});
    states[49] = new State(new int[]{27,50,31,4,32,6,33,8,34,10,35,12,40,14,38,16,36,18,37,20,29,22,30,24,41,26});
    states[50] = new State(-25);
    states[51] = new State(new int[]{28,52});
    states[52] = new State(new int[]{28,27,8,31,9,35,10,39,11,43,12,47,13,51,14,55,15,59,16,63,17,67,18,71,19,75,20,79,21,83,22,87,23,91,24,95,25,99,26,103,3,108,4,109,5,110,6,112,7,113,39,114,32,116,31,118},new int[]{-3,53,-4,30,-5,107,-6,111});
    states[53] = new State(new int[]{27,54,31,4,32,6,33,8,34,10,35,12,40,14,38,16,36,18,37,20,29,22,30,24,41,26});
    states[54] = new State(-26);
    states[55] = new State(new int[]{28,56});
    states[56] = new State(new int[]{28,27,8,31,9,35,10,39,11,43,12,47,13,51,14,55,15,59,16,63,17,67,18,71,19,75,20,79,21,83,22,87,23,91,24,95,25,99,26,103,3,108,4,109,5,110,6,112,7,113,39,114,32,116,31,118},new int[]{-3,57,-4,30,-5,107,-6,111});
    states[57] = new State(new int[]{27,58,31,4,32,6,33,8,34,10,35,12,40,14,38,16,36,18,37,20,29,22,30,24,41,26});
    states[58] = new State(-27);
    states[59] = new State(new int[]{28,60});
    states[60] = new State(new int[]{28,27,8,31,9,35,10,39,11,43,12,47,13,51,14,55,15,59,16,63,17,67,18,71,19,75,20,79,21,83,22,87,23,91,24,95,25,99,26,103,3,108,4,109,5,110,6,112,7,113,39,114,32,116,31,118},new int[]{-3,61,-4,30,-5,107,-6,111});
    states[61] = new State(new int[]{27,62,31,4,32,6,33,8,34,10,35,12,40,14,38,16,36,18,37,20,29,22,30,24,41,26});
    states[62] = new State(-28);
    states[63] = new State(new int[]{28,64});
    states[64] = new State(new int[]{28,27,8,31,9,35,10,39,11,43,12,47,13,51,14,55,15,59,16,63,17,67,18,71,19,75,20,79,21,83,22,87,23,91,24,95,25,99,26,103,3,108,4,109,5,110,6,112,7,113,39,114,32,116,31,118},new int[]{-3,65,-4,30,-5,107,-6,111});
    states[65] = new State(new int[]{27,66,31,4,32,6,33,8,34,10,35,12,40,14,38,16,36,18,37,20,29,22,30,24,41,26});
    states[66] = new State(-29);
    states[67] = new State(new int[]{28,68});
    states[68] = new State(new int[]{28,27,8,31,9,35,10,39,11,43,12,47,13,51,14,55,15,59,16,63,17,67,18,71,19,75,20,79,21,83,22,87,23,91,24,95,25,99,26,103,3,108,4,109,5,110,6,112,7,113,39,114,32,116,31,118},new int[]{-3,69,-4,30,-5,107,-6,111});
    states[69] = new State(new int[]{27,70,31,4,32,6,33,8,34,10,35,12,40,14,38,16,36,18,37,20,29,22,30,24,41,26});
    states[70] = new State(-30);
    states[71] = new State(new int[]{28,72});
    states[72] = new State(new int[]{28,27,8,31,9,35,10,39,11,43,12,47,13,51,14,55,15,59,16,63,17,67,18,71,19,75,20,79,21,83,22,87,23,91,24,95,25,99,26,103,3,108,4,109,5,110,6,112,7,113,39,114,32,116,31,118},new int[]{-3,73,-4,30,-5,107,-6,111});
    states[73] = new State(new int[]{27,74,31,4,32,6,33,8,34,10,35,12,40,14,38,16,36,18,37,20,29,22,30,24,41,26});
    states[74] = new State(-31);
    states[75] = new State(new int[]{28,76});
    states[76] = new State(new int[]{28,27,8,31,9,35,10,39,11,43,12,47,13,51,14,55,15,59,16,63,17,67,18,71,19,75,20,79,21,83,22,87,23,91,24,95,25,99,26,103,3,108,4,109,5,110,6,112,7,113,39,114,32,116,31,118},new int[]{-3,77,-4,30,-5,107,-6,111});
    states[77] = new State(new int[]{27,78,31,4,32,6,33,8,34,10,35,12,40,14,38,16,36,18,37,20,29,22,30,24,41,26});
    states[78] = new State(-32);
    states[79] = new State(new int[]{28,80});
    states[80] = new State(new int[]{28,27,8,31,9,35,10,39,11,43,12,47,13,51,14,55,15,59,16,63,17,67,18,71,19,75,20,79,21,83,22,87,23,91,24,95,25,99,26,103,3,108,4,109,5,110,6,112,7,113,39,114,32,116,31,118},new int[]{-3,81,-4,30,-5,107,-6,111});
    states[81] = new State(new int[]{27,82,31,4,32,6,33,8,34,10,35,12,40,14,38,16,36,18,37,20,29,22,30,24,41,26});
    states[82] = new State(-33);
    states[83] = new State(new int[]{28,84});
    states[84] = new State(new int[]{28,27,8,31,9,35,10,39,11,43,12,47,13,51,14,55,15,59,16,63,17,67,18,71,19,75,20,79,21,83,22,87,23,91,24,95,25,99,26,103,3,108,4,109,5,110,6,112,7,113,39,114,32,116,31,118},new int[]{-3,85,-4,30,-5,107,-6,111});
    states[85] = new State(new int[]{27,86,31,4,32,6,33,8,34,10,35,12,40,14,38,16,36,18,37,20,29,22,30,24,41,26});
    states[86] = new State(-34);
    states[87] = new State(new int[]{28,88});
    states[88] = new State(new int[]{28,27,8,31,9,35,10,39,11,43,12,47,13,51,14,55,15,59,16,63,17,67,18,71,19,75,20,79,21,83,22,87,23,91,24,95,25,99,26,103,3,108,4,109,5,110,6,112,7,113,39,114,32,116,31,118},new int[]{-3,89,-4,30,-5,107,-6,111});
    states[89] = new State(new int[]{27,90,31,4,32,6,33,8,34,10,35,12,40,14,38,16,36,18,37,20,29,22,30,24,41,26});
    states[90] = new State(-35);
    states[91] = new State(new int[]{28,92});
    states[92] = new State(new int[]{28,27,8,31,9,35,10,39,11,43,12,47,13,51,14,55,15,59,16,63,17,67,18,71,19,75,20,79,21,83,22,87,23,91,24,95,25,99,26,103,3,108,4,109,5,110,6,112,7,113,39,114,32,116,31,118},new int[]{-3,93,-4,30,-5,107,-6,111});
    states[93] = new State(new int[]{27,94,31,4,32,6,33,8,34,10,35,12,40,14,38,16,36,18,37,20,29,22,30,24,41,26});
    states[94] = new State(-36);
    states[95] = new State(new int[]{28,96});
    states[96] = new State(new int[]{28,27,8,31,9,35,10,39,11,43,12,47,13,51,14,55,15,59,16,63,17,67,18,71,19,75,20,79,21,83,22,87,23,91,24,95,25,99,26,103,3,108,4,109,5,110,6,112,7,113,39,114,32,116,31,118},new int[]{-3,97,-4,30,-5,107,-6,111});
    states[97] = new State(new int[]{27,98,31,4,32,6,33,8,34,10,35,12,40,14,38,16,36,18,37,20,29,22,30,24,41,26});
    states[98] = new State(-37);
    states[99] = new State(new int[]{28,100});
    states[100] = new State(new int[]{28,27,8,31,9,35,10,39,11,43,12,47,13,51,14,55,15,59,16,63,17,67,18,71,19,75,20,79,21,83,22,87,23,91,24,95,25,99,26,103,3,108,4,109,5,110,6,112,7,113,39,114,32,116,31,118},new int[]{-3,101,-4,30,-5,107,-6,111});
    states[101] = new State(new int[]{27,102,31,4,32,6,33,8,34,10,35,12,40,14,38,16,36,18,37,20,29,22,30,24,41,26});
    states[102] = new State(-38);
    states[103] = new State(new int[]{28,104});
    states[104] = new State(new int[]{28,27,8,31,9,35,10,39,11,43,12,47,13,51,14,55,15,59,16,63,17,67,18,71,19,75,20,79,21,83,22,87,23,91,24,95,25,99,26,103,3,108,4,109,5,110,6,112,7,113,39,114,32,116,31,118},new int[]{-3,105,-4,30,-5,107,-6,111});
    states[105] = new State(new int[]{27,106,31,4,32,6,33,8,34,10,35,12,40,14,38,16,36,18,37,20,29,22,30,24,41,26});
    states[106] = new State(-39);
    states[107] = new State(-5);
    states[108] = new State(-40);
    states[109] = new State(-41);
    states[110] = new State(-42);
    states[111] = new State(-43);
    states[112] = new State(-44);
    states[113] = new State(-45);
    states[114] = new State(new int[]{28,27,8,31,9,35,10,39,11,43,12,47,13,51,14,55,15,59,16,63,17,67,18,71,19,75,20,79,21,83,22,87,23,91,24,95,25,99,26,103,3,108,4,109,5,110,6,112,7,113,39,114,32,116,31,118},new int[]{-3,115,-4,30,-5,107,-6,111});
    states[115] = new State(new int[]{31,-14,32,-14,33,-14,34,-14,35,-14,40,14,38,-14,36,-14,37,-14,29,-14,30,-14,41,26,2,-14,27,-14});
    states[116] = new State(new int[]{28,27,8,31,9,35,10,39,11,43,12,47,13,51,14,55,15,59,16,63,17,67,18,71,19,75,20,79,21,83,22,87,23,91,24,95,25,99,26,103,3,108,4,109,5,110,6,112,7,113,39,114,32,116,31,118},new int[]{-3,117,-4,30,-5,107,-6,111});
    states[117] = new State(-19);
    states[118] = new State(new int[]{28,27,8,31,9,35,10,39,11,43,12,47,13,51,14,55,15,59,16,63,17,67,18,71,19,75,20,79,21,83,22,87,23,91,24,95,25,99,26,103,3,108,4,109,5,110,6,112,7,113,39,114,32,116,31,118},new int[]{-3,119,-4,30,-5,107,-6,111});
    states[119] = new State(-20);

    for (int sNo = 0; sNo < states.Length; sNo++) states[sNo].number = sNo;

    rules[1] = new Rule(-2, new int[]{-1,2});
    rules[2] = new Rule(-1, new int[]{-3});
    rules[3] = new Rule(-3, new int[]{28,-3,27});
    rules[4] = new Rule(-3, new int[]{-4});
    rules[5] = new Rule(-3, new int[]{-5});
    rules[6] = new Rule(-3, new int[]{-3,31,-3});
    rules[7] = new Rule(-3, new int[]{-3,32,-3});
    rules[8] = new Rule(-3, new int[]{-3,33,-3});
    rules[9] = new Rule(-3, new int[]{-3,34,-3});
    rules[10] = new Rule(-3, new int[]{-3,35,-3});
    rules[11] = new Rule(-3, new int[]{-3,40,-3});
    rules[12] = new Rule(-3, new int[]{-3,38,-3});
    rules[13] = new Rule(-3, new int[]{-3,36,-3});
    rules[14] = new Rule(-3, new int[]{39,-3});
    rules[15] = new Rule(-3, new int[]{-3,37,-3});
    rules[16] = new Rule(-3, new int[]{-3,29,-3});
    rules[17] = new Rule(-3, new int[]{-3,30,-3});
    rules[18] = new Rule(-3, new int[]{-3,41});
    rules[19] = new Rule(-3, new int[]{32,-3});
    rules[20] = new Rule(-3, new int[]{31,-3});
    rules[21] = new Rule(-4, new int[]{8,28,-3,27});
    rules[22] = new Rule(-4, new int[]{9,28,-3,27});
    rules[23] = new Rule(-4, new int[]{10,28,-3,27});
    rules[24] = new Rule(-4, new int[]{11,28,-3,27});
    rules[25] = new Rule(-4, new int[]{12,28,-3,27});
    rules[26] = new Rule(-4, new int[]{13,28,-3,27});
    rules[27] = new Rule(-4, new int[]{14,28,-3,27});
    rules[28] = new Rule(-4, new int[]{15,28,-3,27});
    rules[29] = new Rule(-4, new int[]{16,28,-3,27});
    rules[30] = new Rule(-4, new int[]{17,28,-3,27});
    rules[31] = new Rule(-4, new int[]{18,28,-3,27});
    rules[32] = new Rule(-4, new int[]{19,28,-3,27});
    rules[33] = new Rule(-4, new int[]{20,28,-3,27});
    rules[34] = new Rule(-4, new int[]{21,28,-3,27});
    rules[35] = new Rule(-4, new int[]{22,28,-3,27});
    rules[36] = new Rule(-4, new int[]{23,28,-3,27});
    rules[37] = new Rule(-4, new int[]{24,28,-3,27});
    rules[38] = new Rule(-4, new int[]{25,28,-3,27});
    rules[39] = new Rule(-4, new int[]{26,28,-3,27});
    rules[40] = new Rule(-5, new int[]{3});
    rules[41] = new Rule(-5, new int[]{4});
    rules[42] = new Rule(-5, new int[]{5});
    rules[43] = new Rule(-5, new int[]{-6});
    rules[44] = new Rule(-6, new int[]{6});
    rules[45] = new Rule(-6, new int[]{7});
  }

  protected override void Initialize() {
    this.InitSpecialTokens((int)Tokens.error, (int)Tokens.EOF);
    this.InitStates(states);
    this.InitRules(rules);
    this.InitNonTerminals(nonTerms);
  }

  protected override void DoAction(int action)
  {
#pragma warning disable 162, 1522
    switch (action)
    {
      case 2: // expression -> expr
{ expression = ValueStack[ValueStack.Depth-1].expr; }
        break;
      case 3: // expr -> OP_LEFT_PAR, expr, OP_RIGHT_PAR
{ CurrentSemanticValue = ValueStack[ValueStack.Depth-2]; }
        break;
      case 4: // expr -> func
{ CurrentSemanticValue = ValueStack[ValueStack.Depth-1]; }
        break;
      case 5: // expr -> stat
{ CurrentSemanticValue = ValueStack[ValueStack.Depth-1]; }
        break;
      case 6: // expr -> expr, OP_ADD, expr
{ CurrentSemanticValue.expr = new Expression(Operation.Add, ValueStack[ValueStack.Depth-3].expr, ValueStack[ValueStack.Depth-1].expr); }
        break;
      case 7: // expr -> expr, OP_SUB, expr
{ CurrentSemanticValue.expr = new Expression(Operation.Sub, ValueStack[ValueStack.Depth-3].expr, ValueStack[ValueStack.Depth-1].expr); }
        break;
      case 8: // expr -> expr, OP_MUL, expr
{ CurrentSemanticValue.expr = new Expression(Operation.Mul, ValueStack[ValueStack.Depth-3].expr, ValueStack[ValueStack.Depth-1].expr); }
        break;
      case 9: // expr -> expr, OP_DIV, expr
{ CurrentSemanticValue.expr = new Expression(Operation.Div, ValueStack[ValueStack.Depth-3].expr, ValueStack[ValueStack.Depth-1].expr); }
        break;
      case 10: // expr -> expr, OP_MOD, expr
{ CurrentSemanticValue.expr = new Expression(Operation.Mod, ValueStack[ValueStack.Depth-3].expr, ValueStack[ValueStack.Depth-1].expr); }
        break;
      case 11: // expr -> expr, OP_POW, expr
{ CurrentSemanticValue.expr = new Expression(Operation.Pow, ValueStack[ValueStack.Depth-3].expr, ValueStack[ValueStack.Depth-1].expr); }
        break;
      case 12: // expr -> expr, OP_AND, expr
{ CurrentSemanticValue.expr = new Expression(Operation.And, ValueStack[ValueStack.Depth-3].expr, ValueStack[ValueStack.Depth-1].expr); }
        break;
      case 13: // expr -> expr, OP_OR, expr
{ CurrentSemanticValue.expr = new Expression(Operation.Or, ValueStack[ValueStack.Depth-3].expr, ValueStack[ValueStack.Depth-1].expr); }
        break;
      case 14: // expr -> OP_NOT, expr
{ CurrentSemanticValue.expr = new Expression(Operation.Not, ValueStack[ValueStack.Depth-1].expr, null); }
        break;
      case 15: // expr -> expr, OP_XOR, expr
{ CurrentSemanticValue.expr = new Expression(Operation.Xor, ValueStack[ValueStack.Depth-3].expr, ValueStack[ValueStack.Depth-1].expr); }
        break;
      case 16: // expr -> expr, OP_RSH, expr
{ CurrentSemanticValue.expr = new Expression(Operation.Rsh, ValueStack[ValueStack.Depth-3].expr, ValueStack[ValueStack.Depth-1].expr); }
        break;
      case 17: // expr -> expr, OP_LSH, expr
{ CurrentSemanticValue.expr = new Expression(Operation.Lsh, ValueStack[ValueStack.Depth-3].expr, ValueStack[ValueStack.Depth-1].expr); }
        break;
      case 18: // expr -> expr, OP_FAC
{ CurrentSemanticValue.expr = new Expression(Operation.Fac, ValueStack[ValueStack.Depth-2].expr, null); }
        break;
      case 19: // expr -> OP_SUB, expr
{ CurrentSemanticValue.expr.IsNegative = !CurrentSemanticValue.expr.IsNegative; }
        break;
      case 20: // expr -> OP_ADD, expr
{ ; }
        break;
      case 21: // func -> FUNC_FLOOR, OP_LEFT_PAR, expr, OP_RIGHT_PAR
{ CurrentSemanticValue.expr = new Expression(Function.Floor, ValueStack[ValueStack.Depth-2].expr); }
        break;
      case 22: // func -> FUNC_CEIL, OP_LEFT_PAR, expr, OP_RIGHT_PAR
{ CurrentSemanticValue.expr = new Expression(Function.Ceil, ValueStack[ValueStack.Depth-2].expr); }
        break;
      case 23: // func -> FUNC_ROUND, OP_LEFT_PAR, expr, OP_RIGHT_PAR
{ CurrentSemanticValue.expr = new Expression(Function.Round, ValueStack[ValueStack.Depth-2].expr); }
        break;
      case 24: // func -> FUNC_SIN, OP_LEFT_PAR, expr, OP_RIGHT_PAR
{ CurrentSemanticValue.expr = new Expression(Function.Sin, ValueStack[ValueStack.Depth-2].expr); }
        break;
      case 25: // func -> FUNC_COS, OP_LEFT_PAR, expr, OP_RIGHT_PAR
{ CurrentSemanticValue.expr = new Expression(Function.Cos, ValueStack[ValueStack.Depth-2].expr); }
        break;
      case 26: // func -> FUNC_TAN, OP_LEFT_PAR, expr, OP_RIGHT_PAR
{ CurrentSemanticValue.expr = new Expression(Function.Tan, ValueStack[ValueStack.Depth-2].expr); }
        break;
      case 27: // func -> FUNC_ASIN, OP_LEFT_PAR, expr, OP_RIGHT_PAR
{ CurrentSemanticValue.expr = new Expression(Function.Asin, ValueStack[ValueStack.Depth-2].expr); }
        break;
      case 28: // func -> FUNC_ACOS, OP_LEFT_PAR, expr, OP_RIGHT_PAR
{ CurrentSemanticValue.expr = new Expression(Function.Acos, ValueStack[ValueStack.Depth-2].expr); }
        break;
      case 29: // func -> FUNC_ATAN, OP_LEFT_PAR, expr, OP_RIGHT_PAR
{ CurrentSemanticValue.expr = new Expression(Function.Atan, ValueStack[ValueStack.Depth-2].expr); }
        break;
      case 30: // func -> FUNC_SINH, OP_LEFT_PAR, expr, OP_RIGHT_PAR
{ CurrentSemanticValue.expr = new Expression(Function.Sinh, ValueStack[ValueStack.Depth-2].expr); }
        break;
      case 31: // func -> FUNC_COSH, OP_LEFT_PAR, expr, OP_RIGHT_PAR
{ CurrentSemanticValue.expr = new Expression(Function.Cosh, ValueStack[ValueStack.Depth-2].expr); }
        break;
      case 32: // func -> FUNC_TANG, OP_LEFT_PAR, expr, OP_RIGHT_PAR
{ CurrentSemanticValue.expr = new Expression(Function.Tanh, ValueStack[ValueStack.Depth-2].expr); }
        break;
      case 33: // func -> FUNC_ASINH, OP_LEFT_PAR, expr, OP_RIGHT_PAR
{ CurrentSemanticValue.expr = new Expression(Function.Asinh, ValueStack[ValueStack.Depth-2].expr); }
        break;
      case 34: // func -> FUNC_ACOSH, OP_LEFT_PAR, expr, OP_RIGHT_PAR
{ CurrentSemanticValue.expr = new Expression(Function.Acosh, ValueStack[ValueStack.Depth-2].expr); }
        break;
      case 35: // func -> FUNC_ATANH, OP_LEFT_PAR, expr, OP_RIGHT_PAR
{ CurrentSemanticValue.expr = new Expression(Function.Atanh, ValueStack[ValueStack.Depth-2].expr); }
        break;
      case 36: // func -> FUNC_LN, OP_LEFT_PAR, expr, OP_RIGHT_PAR
{ CurrentSemanticValue.expr = new Expression(Function.Ln, ValueStack[ValueStack.Depth-2].expr); }
        break;
      case 37: // func -> FUNC_LG, OP_LEFT_PAR, expr, OP_RIGHT_PAR
{ CurrentSemanticValue.expr = new Expression(Function.Lg, ValueStack[ValueStack.Depth-2].expr); }
        break;
      case 38: // func -> FUNC_EXP, OP_LEFT_PAR, expr, OP_RIGHT_PAR
{ CurrentSemanticValue.expr = new Expression(Function.Exp, ValueStack[ValueStack.Depth-2].expr); }
        break;
      case 39: // func -> FUNC_SQRT, OP_LEFT_PAR, expr, OP_RIGHT_PAR
{ CurrentSemanticValue.expr = new Expression(Function.Sqrt, ValueStack[ValueStack.Depth-2].expr); }
        break;
      case 40: // stat -> NUMBER
{ CurrentSemanticValue.expr = new Expression(ValueStack[ValueStack.Depth-1].String); }
        break;
      case 41: // stat -> NUMBERBIN
{ CurrentSemanticValue.expr = new Expression(ValueStack[ValueStack.Depth-1].String); }
        break;
      case 42: // stat -> NUMBERHEX
{ CurrentSemanticValue.expr = new Expression(ValueStack[ValueStack.Depth-1].String); }
        break;
      case 43: // stat -> const
{ CurrentSemanticValue = ValueStack[ValueStack.Depth-1]; }
        break;
      case 44: // const -> CONST_PI
{ CurrentSemanticValue.expr = new Expression(Constant.Pi); }
        break;
      case 45: // const -> CONST_E
{ CurrentSemanticValue.expr = new Expression(Constant.E); }
        break;
    }
#pragma warning restore 162, 1522
  }

  protected override string TerminalToString(int terminal)
  {
    if (aliasses != null && aliasses.ContainsKey(terminal))
        return aliasses[terminal];
    else if (((Tokens)terminal).ToString() != terminal.ToString(CultureInfo.InvariantCulture))
        return ((Tokens)terminal).ToString();
    else
        return CharToString((char)terminal);
  }


// No argument CTOR. By deafult Parser's ctor requires scanner as param.
public Parser(Scanner scn) : base(scn) { }
}
}
