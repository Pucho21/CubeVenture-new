<h1><strong> Leaderboards </strong></h1>
<h5> This section shows current <strong>leaders</strong> in CubeVenture, based on total score, combined in all levels they have played so far! </h5>

<table>
    <tr>
        <th>Username</th>
        <th>Max Level</th>
        <th>Coins</th>
        <th>Score</th>
    </tr>
    <tbody>

@if(count($leaders) > 0)
    @foreach($leaders as $leader)
        <tr>
            <td>{{ $leader-> username }}</td>
            <td>{{ $leader-> level }}</td>
            <td>{{ $leader-> coins }}</td>
            <td>{{ $leader-> score }}</td>
        </tr>
    @endforeach
@else
@endif

    </tbody>
</table>
