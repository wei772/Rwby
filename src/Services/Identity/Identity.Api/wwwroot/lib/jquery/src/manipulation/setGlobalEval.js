define( [
	"../data/var/dataPriv"
], function( dataPriv ) {

// Mark scripts as having already been evaluated
function setGlobalEval( elems, refElements ) {
	var i = 0,
		l = elems.length;

	for ( ; i < l; i++ ) {
		dataPriv.set(
			elems[ i ],
			"GlobalEval",
			!refElements || dataPriv.get( refElements[ i ], "GlobalEval" )
		);
	}
}

return setGlobalEval;
} );
