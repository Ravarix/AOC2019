my @vals = qw(datazzz);

sub getFuel {
    my $mass = shift;
    my $fuelMass = floor($mass / 3) - 2;
    if ($fuelMass <= 0) {
        return 0;
    } else {
        return $fuelMass + getFuel($fuelMass);
    }
}

my $sum;
$sum += getFuel($_) for @vals;

print $sum;