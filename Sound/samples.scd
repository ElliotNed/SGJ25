(
//
// Spec.add(\index, [0, 40]);
// Spec.add(\harm1, [0, 20, \lin, 1]);
// Spec.add(\harm2, [0, 20, \lin, 1]);
// Spec.add(\fundFreq, \freq);

thisProcess.openUDPPort(57120);

s.waitForBoot({
	Ndef.clear();

	// b = Buffer.read(s, Platform.resourceDir +/+ "sounds/a11wlk01.wav");
	b = Buffer.read(s, thisProcess.nowExecutingPath.dirname +/+ "alchemist.wav");

	SynthDef(\Music, {| out = 0, buf |
		var sig = PlayBuf.ar(2, buf, BufRateScale.kr(buf), loop:1, doneAction: Done.freeSelf);
		sig = LPF.ar(sig, \lpf.kr(200));

		Out.ar(out, sig);
	0}).add;

	OSCdef(\start, {|msg|
		msg.postln;
		Ndef(\PlayBuf, \Music).play;
	}, '/music/start');

	OSCdef(\stop, { |msg|
		msg.postln;
		Ndef(\PlayBuf).stop;
	}, '/music/stop');

	OSCdef(\set, { |msg|
		msg.postln;
		Ndef(\PlayBuf).set(\lpf, 200)
	}, '/music/stop');
});

)


	OSCdef(\s, {|msg|
		msg.postln;
	}, '/pick');

OSCdef.trace(true)
OSCdef.trace(false)