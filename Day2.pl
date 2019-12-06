sub process {
    my ($arr, $idx) = @_;
    my $op = $arr->[$idx];
    
    if ($op eq 1 || $op eq 2) {
        my ($a, $b, $out) = @$arr[$idx+1..$idx+3];
        ($a, $b) = @$arr[$a, $b];
        $arr->[$out] = $op eq 1 ? $a + $b : $a * $b;
    } else {
        print "unknown op code $op" if $op ne 99;
        return;
    }
    process($arr, $idx+4);
}



my $arr = []; #data goes hurr
OUTER: for $noun (0..99){
    for $verb (0..99){
        my $clone = [@$arr];
        $clone->[1] = $noun;
        $clone->[2] = $verb;
        process($clone);
        if ($clone->[0] eq 19690720){
            my $tot = 100 * $noun + $verb;
            print "Noun: $noun, Verb: $verb, Combined: $tot}\n";
            last OUTER;
        }
    }
}