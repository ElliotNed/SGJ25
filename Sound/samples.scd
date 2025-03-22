(
//
// Spec.add(\index, [0, 40]);
// Spec.add(\harm1, [0, 20, \lin, 1]);
// Spec.add(\harm2, [0, 20, \lin, 1]);
// Spec.add(\fundFreq, \freq);

s.waitForBoot({
	Ndef.clear();

	// b = Buffer.read(s, Platform.resourceDir +/+ "sounds/a11wlk01.wav");
	b = Buffer.read(s, thisProcess.nowExecutingPath.dirname +/+ "alchemist.wav");

	SynthDef(\Music, {| out = 0, buf |
		var sig = PlayBuf.ar(2, buf, BufRateScale.kr(buf), loop:1, doneAction: Done.freeSelf);
		sig = LPF.ar(sig, \lpf.kr(200));

		Out.ar(out, sig);
	}).add;

	thisProcess.openUDPPort(57120);
	OSCdef(\start, {
		Ndef(\PlayBuf, \Music).play;
	}, '/music/start');
	OSCdef(\stop, {
		Ndef(\PlayBuf).stop;
	}, '/music/stop');
	OSCdef(\set, { |msg|
		msg.postln;
		Ndef(\PlayBuf).set(\lpf, 200)
	}, '/music/stop');
});

)