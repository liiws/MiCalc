%using MiCalc.Runtime;

%namespace MiCalc.Analyzing

%{
	public Expression expression = new Expression();
%}

%start expression

%union {
	public string String;
	public Expression expr;
}
// Defining Tokens
%token <String>	NUMBER

%token CONST_PI
%token CONST_E

%token FUNC_FLOOR
%token FUNC_CEIL
%token FUNC_ROUND

%token OP_RIGHT_PAR
%token OP_LEFT_PAR
%left OP_ADD OP_SUB
%left OP_MUL OP_DIV
%left OP_MOD
%left OP_POW
%left OP_FAC
%left UMINUS UPLUS


// YACC Rules
%%
expression	: expr { expression = $1.expr; }
			;

expr		: OP_LEFT_PAR expr OP_RIGHT_PAR { $$ = $2; }
			| func { $$ = $1; }
			| stat { $$ = $1; }
			| expr OP_ADD expr { $$.expr = new Expression(Operation.Add, $1.expr, $3.expr); }
			| expr OP_SUB expr { $$.expr = new Expression(Operation.Sub, $1.expr, $3.expr); }
			| expr OP_MUL expr { $$.expr = new Expression(Operation.Mul, $1.expr, $3.expr); }
			| expr OP_DIV expr { $$.expr = new Expression(Operation.Div, $1.expr, $3.expr); }
			| expr OP_MOD expr { $$.expr = new Expression(Operation.Mod, $1.expr, $3.expr); }
			| expr OP_POW expr { $$.expr = new Expression(Operation.Pow, $1.expr, $3.expr); }
			| expr OP_FAC { $$.expr = new Expression(Operation.Fac, $1.expr, null); }
			| OP_SUB expr %prec UMINUS { $$.expr.IsNegative = !$$.expr.IsNegative; }
			| OP_ADD expr %prec UPLUS { ; }
			;

func		: FUNC_FLOOR OP_LEFT_PAR expr OP_RIGHT_PAR { $$.expr = new Expression(Function.Floor, $3.expr); }
			| FUNC_CEIL OP_LEFT_PAR expr OP_RIGHT_PAR { $$.expr = new Expression(Function.Ceil, $3.expr); }
			| FUNC_ROUND OP_LEFT_PAR expr OP_RIGHT_PAR { $$.expr = new Expression(Function.Round, $3.expr); }
			;

stat		: NUMBER { $$.expr = new Expression($1); }
			| const { $$ = $1; }
			;

const		: CONST_PI { $$.expr = new Expression(Constant.Pi); }
			| CONST_E { $$.expr = new Expression(Constant.E); }
			;

%%

// No argument CTOR. By deafult Parser's ctor requires scanner as param.
public Parser(Scanner scn) : base(scn) { }