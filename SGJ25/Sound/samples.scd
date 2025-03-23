(
Spec.add(\distortMul, [0, 1]);
Spec.add(\distortAdd, [0, 10]);
Spec.add(\gain, [0, 1]);
Spec.add(\lpf, [10, 4000, \lin, 1]);

thisProcess.openUDPPort(57120);
Ndef.clear();

s.waitForBoot({

	// b = Buffer.read(s, Platform.resourceDir +/+ "sounds/a11wlk01.wav");
	b = Buffer.read(s, thisProcess.nowExecutingPath.dirname +/+ "alchemist.wav");

	Ndef(\Music, {| out = 0, bufnum = 0 |
		var sig = PlayBuf.ar(2, bufnum, BufRateScale.kr(bufnum), loop:1, doneAction: Done.freeSelf);
		sig = LPF.ar(sig, \lpf.kr(200));
		sig = sig + (sig * WhiteNoise.ar(\distortMul.kr(0.01), \distortAdd.kr(0.01)));
		sig = sig * \gain.kr(1);
		Out.ar(out, sig);
	});

	OSCdef(\start, {|msg|
		msg.postln;
		Ndef(\Music).play;
	}, '/music/start');

	OSCdef(\stop, { |msg|
		msg.postln;
		Ndef(\Music).stop;
	}, '/music/stop');

	OSCdef(\set, { |msg|
		var spec = msg[1].asSymbol;
		var value = spec.asSpec.map(msg[2].asFloat / 100);

		msg.postln;
		Ndef(\Music).set(spec, value)
	}, '/music/set');

});
//
)

//"distortMul".asSymbol.asSpec
//Ndef(\Music).gui

//
// OSCdef(\s, {|msg|
// 	msg.postln;
// }, '/pick');
//
// OSCdef.trace(true)
// OSCdef.trace(false)

// Server.killAll
