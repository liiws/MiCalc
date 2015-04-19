%using MiCalc.Runtime;

%namespace MiCalc.Analyzing

%option stack, minimize, parser, verbose, persistbuffer, unicode, compressNext, embedbuffers, caseInsensitive

//base
D		[0-9]
Number	({D}+\.?{D}*|\.{D}+)(e{D}+)?[a-z]*
NumberBin	[01]+b
NumberHex	[0-9a-f]+h
//whitespace
Space		[ \t]
//[\t\s]
//operators
OpAdd		"+"
OpSub		"-"
OpMul		"*"
OpDiv		"/"
OpMod		"%"
OpPow		"^"
OpFac		"!"
OpAnd		"&"
OpOr		"|"
OpNot		"~"
OpXor		":"
OpRsh		">>"
OpLsh		"<<"
LeftPar		"("
RigthPar	")"
// constants
ConstPi		"pi"
ConstE		"e"
// functions
FuncFloor	"floor"
FuncCeil	"ceil"
FuncRound	"round"
FuncSin		"sin"
FuncCos		"cos"
FuncTan		"tan"
FuncAsin	"asin"
FuncAcos	"acos"
FuncAtan	"atan"
FuncSinh	"sinh"
FuncCosh	"cosh"
FuncTanh	"tanh"
FuncAsinh	"asinh"
FuncAcosh	"acosh"
FuncAtanh	"atanh"
FuncLn		"ln"
FuncLg		"lg"
FuncExp		"exp"
FuncSqrt	"sqrt"

AnyChar		.


// The states into which this FSA can pass.
//%x CMMT		// Inside a comment.
//%x CMMT2	// Inside a comment.
%%

//
// Start of Rules
//

// Remove whitespaces.
{Space}		{ ; }

{NumberBin}	{ yylval.String = yytext; return (int) Tokens.NUMBERBIN; }
{NumberHex}	{ yylval.String = yytext; return (int) Tokens.NUMBERHEX; }
{Number}	{ yylval.String = yytext; return (int) Tokens.NUMBER; }

{OpAdd}		{ return (int) Tokens.OP_ADD; }
{OpSub}		{ return (int) Tokens.OP_SUB; }
{OpMul}		{ return (int) Tokens.OP_MUL; }
{OpDiv}		{ return (int) Tokens.OP_DIV; }
{OpMod}		{ return (int) Tokens.OP_MOD; }
{OpPow}		{ return (int) Tokens.OP_POW; }
{OpFac}		{ return (int) Tokens.OP_FAC; }
{OpAnd}		{ return (int) Tokens.OP_AND; }
{OpOr}		{ return (int) Tokens.OP_OR; }
{OpNot}		{ return (int) Tokens.OP_NOT; }
{OpXor}		{ return (int) Tokens.OP_XOR; }
{OpRsh}		{ return (int) Tokens.OP_RSH; }
{OpLsh}		{ return (int) Tokens.OP_LSH; }
{LeftPar}	{ return (int) Tokens.OP_LEFT_PAR; }
{RigthPar}	{ return (int) Tokens.OP_RIGHT_PAR; }

{ConstPi}	{ return (int) Tokens.CONST_PI; }
{ConstE}	{ return (int) Tokens.CONST_E; }

{FuncFloor}	{ return (int) Tokens.FUNC_FLOOR; }
{FuncCeil}	{ return (int) Tokens.FUNC_CEIL; }
{FuncRound}	{ return (int) Tokens.FUNC_ROUND; }
{FuncSin}	{ return (int) Tokens.FUNC_SIN; }
{FuncCos}	{ return (int) Tokens.FUNC_COS; }
{FuncTan}	{ return (int) Tokens.FUNC_TAN; }
{FuncAsin}	{ return (int) Tokens.FUNC_ASIN; }
{FuncAcos}	{ return (int) Tokens.FUNC_ACOS; }
{FuncAtan}	{ return (int) Tokens.FUNC_ATAN; }
{FuncSinh}	{ return (int) Tokens.FUNC_SINH; }
{FuncCosh}	{ return (int) Tokens.FUNC_COSH; }
{FuncTanh}	{ return (int) Tokens.FUNC_TANG; }
{FuncAsinh}	{ return (int) Tokens.FUNC_ASINH; }
{FuncAcosh}	{ return (int) Tokens.FUNC_ACOSH; }
{FuncAtanh}	{ return (int) Tokens.FUNC_ATANH; }
{FuncLn}	{ return (int) Tokens.FUNC_LN; }
{FuncLg}	{ return (int) Tokens.FUNC_LG; }
{FuncExp}	{ return (int) Tokens.FUNC_EXP; }
{FuncSqrt}	{ return (int) Tokens.FUNC_SQRT; }

// Other chars (disallowed)
//{AnyChar}	{ yyerror("Unknown character"); }
//{AnyChar}	{ ; }
//{AnyChar}	{ return (int) Tokens.WRONG_CHAR; }
{AnyChar}	{ /*if (yytext == " ") { break; }*/ yyerror("Unknown character"); }


