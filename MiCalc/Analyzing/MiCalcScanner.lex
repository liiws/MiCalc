%using MiCalc.Runtime;

%namespace MiCalc.Analyzing

%option stack, minimize, parser, verbose, persistbuffer, unicode, compressNext, embedbuffers, caseInsensitive

%{
public void yyerror(string format, params object[] args) // remember to add override back
{
	System.Console.Error.WriteLine("Error: line {0} - " + format, yyline);
}
%}
//base
D		[0-9]
AZ		[a-zA-Z]
//Name	{AZ}+{D}*
Number	({D}+\.?{D}*|\.{D}+)([eE]{D}+)?
//whitespace
Space		[\t\s]
//operators
OpAdd		"+"
OpSub		"-"
OpMul		"*"
OpDiv		"/"
OpMod		"%"
OpPow		"^"
OpFac		"!"
LeftPar		"("
RigthPar	")"
// constants
ConstPi		"pi"
ConstE		"e"
// functions
FuncFloor	"floor"
FuncCeil	"ceil"
FuncRound	"round"



// The states into which this FSA can pass.
//%x CMMT		// Inside a comment.
//%x CMMT2	// Inside a comment.
%%

//
// Start of Rules
//

//{Name}		{ yylval.String = yytext; return (int) Tokens.NAME; }
{Number}	{ yylval.String = yytext; return (int) Tokens.NUMBER; }

// Remove whitespaces.
{Space}+	{ ; }

{OpAdd}		{ return (int) Tokens.OP_ADD; }
{OpSub}		{ return (int) Tokens.OP_SUB; }
{OpMul}		{ return (int) Tokens.OP_MUL; }
{OpDiv}		{ return (int) Tokens.OP_DIV; }
{OpMod}		{ return (int) Tokens.OP_MOD; }
{OpPow}		{ return (int) Tokens.OP_POW; }
{OpFac}		{ return (int) Tokens.OP_FAC; }
{LeftPar}	{ return (int) Tokens.OP_LEFT_PAR; }
{RigthPar}	{ return (int) Tokens.OP_RIGHT_PAR; }

{ConstPi}	{ return (int) Tokens.CONST_PI; }
{ConstE}	{ return (int) Tokens.CONST_E; }

{FuncFloor}	{ return (int) Tokens.FUNC_FLOOR; }
{FuncCeil}	{ return (int) Tokens.FUNC_CEIL; }
{FuncRound}	{ return (int) Tokens.FUNC_ROUND; }
